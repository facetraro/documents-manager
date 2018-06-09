using DocumentsManager.Data.Logger;
using DocumentsManager.Data.Repository;
using DocumentsManagerDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.DA.Handler
{
    public class LoggerContext
    {
        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }
        public List<LoggerType> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.LoggerRepository.Get().ToList();
            }
        }
        public void Remove(LoggerType logToDelete)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.LoggerRepository.Delete(logToDelete);
            }
        }
        public void Remove(Guid id)
        {
            LoggerType logToDelete = GetById(id);
            if (logToDelete != null)
            {
                Remove(logToDelete);
            }
        }
        public LoggerType GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                LoggerType log = unitOfWork.LoggerRepository.GetByID(id);
                return log;
            }
        }
        public bool Exists(LoggerType aLog)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.LoggerRepository.Exists(aLog.Id);
            }
        }
        public void Add(LoggerType newLog)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.LoggerRepository.Insert(newLog);
            }
        }

    }
}
