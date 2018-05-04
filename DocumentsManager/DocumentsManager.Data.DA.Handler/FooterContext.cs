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
                newFooter.Text = db.Texts.Find(newFooter.Text.Id);

                unitOfWork.FooterRepository.Insert(newFooter);
            }
        }
        public void Remove(Footer footerToDelete)
        {
            //TextContext contextT = new TextContext();
            //Text textToDelete = contextT.GetById(headerToDelete.Text.Id);
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FooterRepository.Delete(footerToDelete);
            }
            //contextT.Remove(textToDelete);
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
                db.Headers.Include("StyleClass").ToList().FirstOrDefault();// tiene que ser con style y text
                db.Headers.Include("Text").ToList().FirstOrDefault();
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

            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FooterRepository.Update(modifiedFooter);
            }
            UpdateStyle(modifiedFooter);
            TextContext tContext = new TextContext();
            tContext.Modify(tContext.GetById(modifiedFooter.Text.Id));
        }
    }
}
