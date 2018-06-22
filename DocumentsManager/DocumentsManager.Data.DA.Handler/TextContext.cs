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

        public void ClearOnlyInParragraphs()
        {
            throw new NotImplementedException();
        }

        public void Remove(Text textDelete)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.TextRepository.Delete(textDelete);
            }
        }

        internal bool Exists(Text texti)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.TextRepository.Exists(texti.Id);
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
            StyleClassContextHandler sContext = new StyleClassContextHandler();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Text theText = unitOfWork.TextRepository.GetByID(id);
                db.Texts.Include("StyleClass").ToList().FirstOrDefault();
                if (theText != null && theText.StyleClass != null)
                {
                    theText.StyleClass = sContext.GetById(theText.StyleClass.Id);
                }
                return theText;
            }
        }
       
        public void Modify(Text modifiedText)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Text textEntity = db.Texts.Find(modifiedText.Id);
                textEntity.WrittenText = modifiedText.WrittenText;
                db.Styles.Attach(modifiedText.StyleClass);
                textEntity.StyleClass = modifiedText.StyleClass;
                unitOfWork.TextRepository.Update(textEntity);
               
                unitOfWork.Save();
            }
        }
    }
}
