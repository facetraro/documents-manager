﻿using DocumentsManager.AuthenticationToken;
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
        public void ModifyParragraphs(Document aDocument, User responsibleUser)
        {
            AddModifyHistory(responsibleUser, aDocument, ModifyState.Modified);
            DocumentContext documentContext = new DocumentContext();
            documentContext.ModifyParragraphs(aDocument);
        }

        public void AddDocument(Document aDocument, User responsibleUser)
        {
            DocumentContext documentContext = new DocumentContext();
            documentContext.Add(aDocument);
            AddModifyHistory(responsibleUser, aDocument, ModifyState.Added);
        }
        public void ModifyDocumentProperties(Document aDocument, User responsibleUser) {
            DocumentContext documentContext = new DocumentContext();
            documentContext.ModifyProperties(aDocument);
            AddModifyHistory(responsibleUser, aDocument, ModifyState.Modified);
        }
        public void ModifyDocumentHeader(Document aDocument, User responsibleUser) {
            DocumentContext documentContext = new DocumentContext();
            documentContext.ModifyHeader(aDocument);
            AddModifyHistory(responsibleUser, aDocument, ModifyState.Modified);
        }
        public void ModifyDocumentFooter(Document aDocument, User responsibleUser)
        {
            DocumentContext documentContext = new DocumentContext();
            documentContext.ModifyFooter(aDocument);
            AddModifyHistory(responsibleUser, aDocument, ModifyState.Modified);
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
            return uContext.GetById(id);
        }
        public Guid LogIn(string username, string password)
        {
            User anUser = new AdminUser();
            anUser.Username = username;
            if (UserNameRegistered(anUser))
            {
                User userFromDB = GetUserByUsername(username);
                if (userFromDB.Authenticate(password))
                {
                    SessionAccess sessionAccess = new SessionAccess();
                    return sessionAccess.Add(userFromDB.Id);
                }
            }
            throw new InvalidCredentialException();
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
    }
}