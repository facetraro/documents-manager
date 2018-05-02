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
    public class TextContext
    {
        public List<Text> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.TextRepository.Get().ToList();
            }
        }
        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }
        public void Add(Text newText)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(newText.StyleClass);
                unitOfWork.TextRepository.Insert(newText);
            }
        }
        public void Remove(Text textDelete)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.TextRepository.Delete(textDelete);
            }
        }
        public void Remove(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.TextRepository.Delete(id);
            }
        }
        public Text GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);

                Text theText = unitOfWork.TextRepository.GetByID(id);
                db.Texts.Include("StyleClass").ToList().FirstOrDefault();
                return theText;
            }
        }
        private void UpdateStyle(Text modifiedText)
        {
            using (var db = new ContextDataAccess())
            {
                db.Texts.Attach(modifiedText);
                db.Entry(modifiedText).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Modify(Text modifiedText)
        {
            
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.TextRepository.Update(modifiedText);
            }
            UpdateStyle(modifiedText);
        }
    }
}
