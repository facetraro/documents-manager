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
        public void UpdateFormat(Format modifiedFormat)
        {
            using (var db = new ContextDataAccess())
            {
                Format old = db.Formats.Find(modifiedFormat.Id);
                old.StyleClasses = new List<StyleClass>();
                foreach (var item in modifiedFormat.StyleClasses)
                {
                    old.StyleClasses.Add(db.Styles.Find(item.Id));
                }
                old.Name = modifiedFormat.Name;
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FormatRepository.Update(old);
            }
        }
        public void DeleteOldStyles(Format modifiedFormat)
        {
            Format oldFormat = GetById(modifiedFormat.Id);
            using (var db = new ContextDataAccess())
            {
                modifiedFormat = db.Set<Format>().Attach(modifiedFormat);
                db.Entry(modifiedFormat).Collection(p => p.StyleClasses).Load();
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FormatRepository.Update(modifiedFormat);
            }
        }
        public bool Exists(Guid formatGuid)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.FormatRepository.Exists(formatGuid);
            }
        }

        public void Modify(Format modifiedFormat)
        {
            UpdateFormat(modifiedFormat);
            DeleteOldStyles(modifiedFormat);
        }
        public List<Format> GetFormats()
        {
            List<Format> formats = new List<Format>();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                formats = unitOfWork.FormatRepository.Get().ToList();
            }
            return formats;
        }
        public List<Format> GetEagerFormats()
        {
            List<Format> formats = new List<Format>();
            foreach (var item in GetFormats())
            {
                formats.Add(GetById(item.Id));
            }
            return formats;
           
        }
    }
}
