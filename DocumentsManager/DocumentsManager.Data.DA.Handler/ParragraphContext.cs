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
       
        public void Add(Parragraph aParragraph)
        {
            List<Text> texts = aParragraph.Texts;
            Parragraph newParragraph = new Parragraph();
            newParragraph.StyleClass = aParragraph.StyleClass;
            newParragraph.Id = aParragraph.Id;
            newParragraph.Texts = new List<Text>();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(newParragraph.StyleClass);
                foreach (Text texti in texts)
                {
                    newParragraph.AddText(db.Texts.Find(texti.Id));
                }
                unitOfWork.ParragraphRepository.Insert(newParragraph);
            }
        }
       
    }
}
