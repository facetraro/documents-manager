using DocumentsManager.Data.Repository;
using DocumentsManagerDataAccess;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.DA.Handler
{
    public class FooterContext
    {
        public List<Footer> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.FooterRepository.Get().ToList();
            }
        }
        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }
        public void Add(Footer newFooter)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(newFooter.StyleClass);
                newFooter.Text.StyleClass = db.Styles.Find(newFooter.Text.StyleClass.Id);
                unitOfWork.FooterRepository.Insert(newFooter);
            }
        }
        public void Remove(Footer footerToDelete)
        {
            Footer footer = GetById(footerToDelete.Id);
            using (var db = new ContextDataAccess())
            {
                Footer footerFromDB = GetById(footerToDelete.Id);
                var unitOfWork = new UnitOfWork(db);
                if (footerFromDB != null)
                {
                    footerFromDB.Text.StyleClass = null;
                    unitOfWork.FooterRepository.Delete(footerFromDB.Id);
                }
            }
            if (footer != null)
            {
                TextContext tContext = new TextContext();
                tContext.Remove(footer.Text);
            }
        }
        public void Remove(Guid id)
        {
            Footer footer = GetById(id);
            using (var db = new ContextDataAccess())
            {

                Footer footerFromDB = GetById(id);
                var unitOfWork = new UnitOfWork(db);
                if (footerFromDB != null)
                {
                    footerFromDB.Text.StyleClass = null;
                    unitOfWork.FooterRepository.Delete(footerFromDB.Id);
                }
            }
            if (footer != null)
            {
                TextContext tContext = new TextContext();
                tContext.Remove(footer.Text);
            }

        }
        public Footer GetById(Guid id)
        {
            TextContext tContext = new TextContext();
            StyleClassContextHandler sContext = new StyleClassContextHandler();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);

                Footer theFooter = unitOfWork.FooterRepository.GetByID(id);
                db.Footers.Include("StyleClass").ToList().FirstOrDefault();
                db.Footers.Include("Text").ToList().FirstOrDefault();
                if (theFooter != null)
                {
                    theFooter.Text = tContext.GetById(theFooter.Text.Id);
                    theFooter.StyleClass = sContext.GetById(theFooter.StyleClass.Id);
                }
                return theFooter;
            }
        }
        public void Modify(Footer modifiedFooter)
        {
            TextContext tContext = new TextContext();
            Text oldText = new Text();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Footer footerEntity = db.Footers.Find(modifiedFooter.Id);
                oldText = tContext.GetById(footerEntity.Text.Id);
                footerEntity.StyleClass = db.Styles.Find(modifiedFooter.StyleClass.Id); 
                unitOfWork.FooterRepository.Update(footerEntity);
                oldText.WrittenText = modifiedFooter.Text.WrittenText;
                oldText.StyleClass = modifiedFooter.Text.StyleClass;
            }
            tContext.Modify(oldText);
        }
    }
}
