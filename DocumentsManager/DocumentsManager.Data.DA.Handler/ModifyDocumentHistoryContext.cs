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
                return unitOfWork.HistoryRepository.Get().ToList();
            }
        }
    }
}
