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
                db.Users.Attach(newHistory.User);
                newHistory.Document = db.Documents.Find(newHistory.Document.Id);
                unitOfWork.HistoryRepository.Insert(newHistory);
            }
        }
        public List<ModifyDocumentHistory> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.HistoryRepository.Get().ToList();
            }
        }
        public List<ModifyDocumentHistory> GetAllHistories()
        {
            List<ModifyDocumentHistory> allHistories = new List<ModifyDocumentHistory>();
            foreach (var item in GetLazy())
            {
                allHistories.Add(GetById(item.Id));
            }
            return allHistories;
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
        public List<Document> GetDocumentsFromUser(User user)
        {
            DocumentContext dContext = new DocumentContext();
            List<Document> documentsFromUser = new List<Document>();
            foreach (ModifyDocumentHistory historyi in GetAllHistories())
            {
                if (historyi.User.Equals(user) && historyi.State == ModifyState.Added)
                {
                    documentsFromUser.Add(dContext.GetById(historyi.Document.Id));
                }
            }
            return documentsFromUser;
        }
    }
}
