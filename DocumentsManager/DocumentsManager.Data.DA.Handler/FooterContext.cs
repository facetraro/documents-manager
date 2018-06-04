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
            
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FooterRepository.Delete(footerToDelete);
            }
            Footer footer = GetById(footerToDelete.Id);
            if (footer != null)
            {
                TextContext tContext = new TextContext();
                tContext.Remove(footer.Text);
            }
        }
        public void Remove(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FooterRepository.Delete(id);
            }
            Footer footer = GetById(id);
            if (footer!=null)
            {
                TextContext tContext = new TextContext();
                tContext.Remove(footer.Text);
            }
            
        }
        public Footer GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);

                Footer theFooter = unitOfWork.FooterRepository.GetByID(id);
                db.Footers.Include("StyleClass").ToList().FirstOrDefault();
                db.Footers.Include("Text").ToList().FirstOrDefault();
                return theFooter;
            }
        }
        public void Modify(Footer modifiedFooter)
        {
            Text oldText = new Text();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Footer footerEntity = db.Footers.Find(modifiedFooter.Id);
                oldText.WrittenText = modifiedFooter.Text.WrittenText;
                oldText.Id = footerEntity.Text.Id;
                oldText.StyleClass = modifiedFooter.Text.StyleClass;
                footerEntity.StyleClass = db.Styles.Find(modifiedFooter.StyleClass.Id); 
                unitOfWork.FooterRepository.Update(footerEntity);
            }
            TextContext tContext = new TextContext();
            tContext.Modify(oldText);
        }
    }
}
