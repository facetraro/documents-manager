using DocumentsManager.Data.Repository;
using DocumentsManagerDataAccess;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.DA.Handler
{
    public class ParragraphContext
    {
        public List<Parragraph> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.ParragraphRepository.Get().ToList();
            }
        }
        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }
        public void Add(Parragraph aParragraph)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(aParragraph.StyleClass);
                if (aParragraph.Document!=null)
                {
                    aParragraph.Document = db.Documents.Find(aParragraph.Document.Id);
                }
                unitOfWork.ParragraphRepository.Insert(aParragraph);
            }
        }
        public void Remove(Parragraph parragraphToDelete)
        {
           
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Parragraph parragraph = GetById(parragraphToDelete.Id);
                int lenghtText = parragraph.Texts.Count;
                for (int i = 0; i < lenghtText; i++)
                {
                    unitOfWork.TextRepository.Delete(parragraph.Texts[i]);
                }
                parragraph = GetById(parragraphToDelete.Id);
                parragraph.StyleClass = null;
                unitOfWork.ParragraphRepository.Delete(parragraph);
            }
        }
        public void Remove(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Parragraph parragraph = GetById(id);
                if (parragraph!=null)
                {
                  int lenghtText = parragraph.Texts.Count;
                  for (int i = 0; i < lenghtText; i++)
                  {
                      unitOfWork.TextRepository.Delete(parragraph.Texts[i]);
                  }
                  db.Styles.Attach(parragraph.StyleClass);
                  unitOfWork.ParragraphRepository.Delete(id);
                }
                
            }
        }
        public Parragraph GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);

                Parragraph theParragraph = unitOfWork.ParragraphRepository.GetByID(id);
                db.Parragraphs.Include("StyleClass").ToList().FirstOrDefault();
                db.Parragraphs.Include("Texts").ToList();
                return theParragraph;
            }
        }
        public void Modify(Parragraph modifiedParragraph,Parragraph oldParragraph)
        {
            modifiedParragraph.StyleClass.Attributes = new List<StyleAttribute>();
            TextContext contextT = new TextContext();
            for (int i = 0; i < oldParragraph.Texts.Count; i++)
            {
                contextT.Remove(oldParragraph.Texts.ElementAt(i));
            }
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Parragraph parragraphEntity = db.Parragraphs.Find(modifiedParragraph.Id);
                parragraphEntity.Texts = modifiedParragraph.Texts;
                parragraphEntity.StyleClass = modifiedParragraph.StyleClass;
                db.Styles.Attach(parragraphEntity.StyleClass);
                unitOfWork.ParragraphRepository.Update(parragraphEntity);
                unitOfWork.Save();
            }
        }


    }
}
