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
    }
}
