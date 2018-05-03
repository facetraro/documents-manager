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

        public void Remove(Format formatToDelete)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FormatRepository.Delete(formatToDelete);
            }
        }
        public Format GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Format format = unitOfWork.FormatRepository.GetByID(id);
                db.Formats.Include("StyleClasses").ToList();
                return format;
            }
        }
        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }

        public void Modify(Format modifiedFormat)
        {
            Format oldFormat = GetById(modifiedFormat.Id);
            using (var db = new ContextDataAccess())
            {
                modifiedFormat = db.Set<Format>().Attach(modifiedFormat);
                db.Entry(modifiedFormat).Collection(p => p.StyleClasses).Load();
                db.Entry(modifiedFormat).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
