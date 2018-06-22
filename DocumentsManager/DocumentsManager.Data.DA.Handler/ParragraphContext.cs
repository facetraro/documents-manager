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
            TextContext tContext = new TextContext();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(aParragraph.StyleClass);
                if (aParragraph.Document != null)
                {
                    aParragraph.Document = db.Documents.Find(aParragraph.Document.Id);
                }
                foreach (Text texti in aParragraph.Texts)
                {
                    Text aText = texti;
                    if (tContext.Exists(texti))
                    {
                        aText = tContext.GetById(texti.Id);
                    }
                    if (texti.StyleClass != null)
                    {
                        texti.StyleClass = db.Styles.Find(aText.StyleClass.Id);
                    }

                }
                unitOfWork.ParragraphRepository.Insert(aParragraph);
            }
        }

        public void ClearParragraphTexts()
        {
            TextContext tContext = new TextContext();
            foreach (Parragraph pi in GetLazy())
            {
                Parragraph actualParragraph = GetById(pi.Id);
                foreach (Text ti in actualParragraph.Texts)
                {
                    tContext.Remove(ti.Id);
                }
            }
        }

        public void Remove(Parragraph parragraphToDelete)
        {
            TextContext tContext = new TextContext();
            Parragraph parragraph = GetById(parragraphToDelete.Id);
            int lenghtText = parragraph.Texts.Count;
            for (int i = 0; i < lenghtText; i++)
            {
                tContext.Remove(parragraph.Texts[i]);
            }
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
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
                if (parragraph != null)
                {
                    int lenghtText = parragraph.Texts.Count;
                    for (int i = 0; i < lenghtText; i++)
                    {
                        unitOfWork.TextRepository.Delete(parragraph.Texts[i]);
                    }
                    parragraph.StyleClass = db.Styles.Find(parragraph.StyleClass.Id);
                    unitOfWork.ParragraphRepository.Delete(id);
                }

            }
        }
        public Parragraph GetById(Guid id)
        {
            TextContext tContext = new TextContext();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);

                Parragraph theParragraph = unitOfWork.ParragraphRepository.GetByID(id);
                db.Parragraphs.Include("StyleClass").ToList().FirstOrDefault();
                db.Parragraphs.Include("Texts").ToList();
                List<Text> eagerTexts = new List<Text>();
                if (theParragraph != null)
                {
                    foreach (Text ti in theParragraph.Texts)
                    {
                        eagerTexts.Add(tContext.GetById(ti.Id));
                    }
                    theParragraph.Texts = eagerTexts;
                }
                return theParragraph;
            }
        }
        public void Modify(Parragraph modifiedParragraph, Parragraph oldParragraph)
        {
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
                parragraphEntity.StyleClass = db.Styles.Find(modifiedParragraph.StyleClass.Id);
                unitOfWork.ParragraphRepository.Update(parragraphEntity);
                unitOfWork.Save();
            }
        }
        public bool Exists(Parragraph aParragraph)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.ParragraphRepository.Exists(aParragraph.Id);
            }
        }


    }
}
