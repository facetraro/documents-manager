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
        }
        public void Remove(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FooterRepository.Delete(id);
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
        private void UpdateStyle(Footer modifiedFooter)
        {
            using (var db = new ContextDataAccess())
            {
                db.Footers.Attach(modifiedFooter);
                db.Entry(modifiedFooter).State = EntityState.Modified;
                db.SaveChanges();
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
                db.Styles.Attach(modifiedFooter.StyleClass);
                footerEntity.StyleClass = modifiedFooter.StyleClass;
                unitOfWork.FooterRepository.Update(footerEntity);
            }
            TextContext tContext = new TextContext();
            tContext.Modify(oldText);
        }
    }
}
