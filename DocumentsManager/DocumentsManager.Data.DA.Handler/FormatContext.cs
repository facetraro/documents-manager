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
    public class FormatContext
    {
        public void Add(Format newFormat)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                foreach (var item in newFormat.StyleClasses)
                {
                    db.Styles.Attach(item);
                }
                unitOfWork.FormatRepository.Insert(newFormat);
            }
        }

        public List<Format> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.FormatRepository.Get().ToList();
            }
        }
    }
}
