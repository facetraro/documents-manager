using DocumentsManager.AuthenticationToken;
using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsManager.ProxyInterfaces;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class UserBusinessLogic : IUserBusinessLogic
    {

        public Guid CreateADocument(Document doc, Guid tokenId)
        {
            User responsibleUser = GetUserByToken(tokenId);
            return AddDocument(doc, responsibleUser);
        }

        public bool UpdateADocument(Guid id, Document aDocument, Guid tokenId)
        {
            User responsibleUser = GetUserByToken(tokenId);
            return UpdateDocument(id, aDocument, responsibleUser);
        }

        public bool DeleteADocument(Document aDocument, Guid tokenId)
        {
            DocumentBusinessLogic documentBl = new DocumentBusinessLogic();
            if (documentBl.AlreadyDeleted(aDocument))
            {
                throw new DocumentAlreadyDeleted();
            }
            User responsibleUser = GetUserByToken(tokenId);
            return DeleteDocument(aDocument, responsibleUser);
        }
        private User GetLoggedUser(Guid tokenId)
        {
            return GetUserByToken(tokenId);
        }
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
        public Guid AddDocument(Document doc, User responsibleUser)
        {
               
                if (!IdRegistered(responsibleUser))
                {
                    throw new ObjectDoesNotExists(responsibleUser);
                }
                DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
                Guid id = documentLogic.Add(doc);
                AddModifyHistory(responsibleUser, doc, ModifyState.Added);
                return id;
                        
        }
        public bool DeleteDocument(Document aDocument, User responsibleUser)
        {
            AddModifyHistory(responsibleUser, aDocument, ModifyState.Removed);
            return true;
        }


        public bool UpdateDocument(Guid id, Document aDocument, User responsibleUser)
        {
            DocumentBusinessLogic documentBL = new DocumentBusinessLogic();
            if (!documentBL.Exists(id))
            {
                throw new ObjectDoesNotExists(aDocument);
            }
            this.ModifyDocumentProperties(aDocument, responsibleUser);
            this.ModifyDocumentFooter(aDocument, responsibleUser);
            this.ModifyDocumentHeader(aDocument, responsibleUser);
            this.ModifyParragraphs(aDocument, responsibleUser);
            return true;
        }

        public void ModifyDocument(User user, Document doc, ModifyState state)
        {
            AddModifyHistory(user, doc, state);
        }
       
        public void ModifyParragraphs(Document aDocument, User responsibleUser)
        {
            DocumentContext documentContext = new DocumentContext();
            documentContext.ModifyParragraphs(aDocument);
        }

       
        public void ModifyDocumentProperties(Document aDocument, User responsibleUser)
        {
            DocumentContext documentContext = new DocumentContext();
            documentContext.ModifyProperties(aDocument);
            AddModifyHistory(responsibleUser, aDocument, ModifyState.Modified);
        }
        public void ModifyDocumentHeader(Document aDocument, User responsibleUser)
        {
            DocumentContext documentContext = new DocumentContext();
            documentContext.ModifyHeader(aDocument);
        }
        public void ModifyDocumentFooter(Document aDocument, User responsibleUser)
        {
            DocumentContext documentContext = new DocumentContext();
            documentContext.ModifyFooter(aDocument);
        }
        public User GetUserByUsername(string username)
        {
            UserContext uContext = new UserContext();
            List<User> allUsers = uContext.GetLazy();
            foreach (User useri in allUsers)
            {
                if (useri.Username.Equals(username))
                {
                    return useri;
                }
            }
            return null;
        }
        public User GetUserById(Guid id)
        {
            UserContext uContext = new UserContext();
            User userToSearch = new AdminUser
            {
                Id = id
            };
            if (!uContext.Exists(userToSearch))
            {
                throw new ObjectDoesNotExists(uContext);
            }
            return uContext.GetById(id);
        }
        protected User AuthenticateUser(string username, string password)
        {
            User anUser = new AdminUser();
            anUser.Username = username;
            if (UserNameRegistered(anUser))
            {
                User userFromDB = GetUserByUsername(username);
                if (userFromDB.Authenticate(password))
                {
                    return userFromDB;
                }
            }
            throw new InvalidCredentialException();
        }
        public Guid LogIn(string username, string password)
        {
            User userFromDB = AuthenticateUser(username, password);
            if (userFromDB != null)
            {
                SessionAccess sessionAccess = new SessionAccess();
                Guid newToken = sessionAccess.Add(userFromDB.Id);
                return newToken;
            }
            return new Guid();
        }
        private Guid GetIdByToken(Guid token)
        {
            SessionAccess sessionAccess = new SessionAccess();
            return sessionAccess.GetIdByToken(token);
        }
        public User GetUserByToken(Guid token)
        {
            Guid idUser = GetIdByToken(token);
            return GetUserById(idUser);
        }
        public bool IsTokenActive(Guid token)
        {
            SessionAccess sessionAccess = new SessionAccess();
            return sessionAccess.IsTokenActive(token);
        }
        public void LogOut(Guid token)
        {
            SessionAccess sessionAccess = new SessionAccess();
            sessionAccess.Remove(token);
        }

        public void ReleaseAllSessions()
        {
            SessionAccess sessionAccess = new SessionAccess();
            sessionAccess.ClearAll();
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

        public List<Document> GetDocumentsFromUser(User user, Guid tokenId)
        {
            ModifyDocumentHistoryContext mContext = new ModifyDocumentHistoryContext();
            return mContext.GetDocumentsFromUser(user);
        }
        public bool AreFriends(User anUser, User anotherUser) {
            bool areFriends = false;
            FriendshipContext fshContext = new FriendshipContext();
            List<Friendship> relationships = fshContext.GetAllFriendships();
            foreach (Friendship relationi in relationships)
            {
                if (relationi.IsFriendship() && relationi.Request.Equals(anUser) && relationi.Requested.Equals(anotherUser))
                {
                    areFriends = true;
                }
                if (relationi.IsFriendship() && relationi.Request.Equals(anotherUser) && relationi.Requested.Equals(anUser))
                {
                    areFriends = true;
                }
            }
            return areFriends;
        }
    }
}