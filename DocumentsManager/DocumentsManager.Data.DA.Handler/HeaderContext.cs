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
    public class HeaderContext
    {
        public List<Header> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.HeaderRepository.Get().ToList();
            }
        }
        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }
        public void Add(Header newHeader)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(newHeader.StyleClass);
                newHeader.Text=db.Texts.Find(newHeader.Text.Id);
                
                unitOfWork.HeaderRepository.Insert(newHeader);
            }
        }
        public void Remove(Header headerToDelete)
        {
            //TextContext contextT = new TextContext();
            //Text textToDelete = contextT.GetById(headerToDelete.Text.Id);
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.HeaderRepository.Delete(headerToDelete);
            }
            //contextT.Remove(textToDelete);
        }
        public void Remove(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.HeaderRepository.Delete(id);
            }
        }
        public Header GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                 
                Header theHeader = unitOfWork.HeaderRepository.GetByID(id);
                db.Headers.Include("StyleClass").ToList().FirstOrDefault();// tiene que ser con style y text
                db.Headers.Include("Text").ToList().FirstOrDefault();
                return theHeader;
            }
        }
        private void UpdateStyle(Header modifiedHeader)
        {
            using (var db = new ContextDataAccess())
            {
                db.Headers.Attach(modifiedHeader);
                db.Entry(modifiedHeader).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Modify(Header modifiedHeader)
        {

            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.HeaderRepository.Update(modifiedHeader);
            }
            UpdateStyle(modifiedHeader);
            TextContext tContext = new TextContext();
            tContext.Modify(tContext.GetById(modifiedHeader.Text.Id));
        }
    }
}
