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
    public class ModifyDocumentHistoryContext
    {
        public void Add(ModifyDocumentHistory newHistory)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Documents.Attach(newHistory.Document);
                db.Users.Attach(newHistory.User);
                unitOfWork.HistoryRepository.Insert(newHistory);
            }
        }
        public List<ModifyDocumentHistory> GetAllHistories()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                List<ModifyDocumentHistory> lazy = unitOfWork.HistoryRepository.Get().ToList();
                List<ModifyDocumentHistory> allHistories = new List<ModifyDocumentHistory>();
                foreach (var item in lazy)
                {
                    allHistories.Add(GetById(item.Id));
                }
                return allHistories;
            }
        }
        public void ClearAll()
        {
            foreach (var item in GetAllHistories())
            {
                Remove(item);
            }
        }
        public void Remove(ModifyDocumentHistory newHistory)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.HistoryRepository.Delete(newHistory);
            }
        }
        public ModifyDocumentHistory GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                ModifyDocumentHistory history = unitOfWork.HistoryRepository.GetByID(id);
                db.Histories.Include("User").ToList();
                db.Histories.Include("Document").ToList();
                return history;
            }
        }
    }
}
