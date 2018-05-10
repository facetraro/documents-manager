using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class UserBusinessLogic
    {
        private void AddModifyHistory(User user, Document doc, ModifyState state)
        {
            ModifyDocumentHistory history = new ModifyDocumentHistory();
            history.Document = doc;
            history.User = user;
            history.Date = DateTime.Today;
            history.Id = Guid.NewGuid();
            history.State = state;
            ModifyDocumentHistoryContext modifyContext = new ModifyDocumentHistoryContext();
            modifyContext.Add(history);
        }
        public Guid AddDocument(User user, Document doc)
        {
            if (!IdRegistered(user))
            {
                throw new ObjectDoesNotExists(user);
            }
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Guid id = documentLogic.Add(doc);
            AddModifyHistory(user, doc, ModifyState.Added);
            return id;
        }
        public void ModifyDocument(User user, Document doc, ModifyState state)
        {
            AddModifyHistory(user, doc, state);
        }
        public bool IdRegistered(User anUser)
        {
            UserContext uContext = new UserContext();
            return uContext.Exists(anUser);
        }
        public bool UserNameRegistered(User anUser)
        {
            UserContext uContext = new UserContext();
            List<User> allUsers = uContext.GetLazy();
            bool registered = false;
            foreach (User useri in allUsers)
            {
                if (useri.Username.Equals(anUser.Username))
                {
                    registered = true;
                }
            }
            return registered;
        }
        public bool EmailRegistered(User anUser)
        {
            UserContext uContext = new UserContext();
            List<User> allUsers = uContext.GetLazy();
            bool registered = false;
            foreach (User useri in allUsers)
            {
                if (useri.Email.Equals(anUser.Email))
                {
                    registered = true;
                }
            }
            return registered;
        }
    }
}