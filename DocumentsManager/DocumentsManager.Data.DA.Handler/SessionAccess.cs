using DocumentsManager.AuthenticationToken;
using DocumentsManager.Data.Repository;
using DocumentsManager.Exceptions;
using DocumentsManagerDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.AuthenticationToken
{
    public class SessionAccess
    {
        public Guid Add(Guid idToLog)
        {
            Session newSession = new Session
            {
                idLogged = idToLog,
                token = Guid.NewGuid()
            };
            if (!SessionAlreadyOpen(idToLog))
            {
                using (var db = new ContextDataAccess())
                {
                    var unitOfWork = new UnitOfWork(db);
                    unitOfWork.SessionRepository.Insert(newSession);
                    return newSession.token;
                }
            }
            throw new UserAlreadyLogged();
        }
        public void Remove(Guid token)
        {
            try
            {
                using (var db = new ContextDataAccess())
                {
                    var unitOfWork = new UnitOfWork(db);
                    unitOfWork.SessionRepository.Delete(token);
                }
            }
            catch (Exception e)
            {
                throw new LostConnectionWithDataBase();
            }
        }
    public bool SessionAlreadyOpen(Guid id)
    {
        try
        {
            using (var context = new ContextDataAccess())
            {
                foreach (var item in context.ActiveSessions.ToList())
                {
                    if (id == item.idLogged) return true;
                }
                return false;
            }
        }
        catch (Exception)
        {
            throw new LostConnectionWithDataBase();
        }
    }
    public void ClearAll()
    {
        try
        {
            using (var context = new ContextDataAccess())
            {
                foreach (Session item in context.ActiveSessions.ToList())
                {
                    Remove(item.token);
                }
            }
        }
        catch (Exception)
        {
            throw new LostConnectionWithDataBase();
        }
    }

    public Guid GetIdByToken(Guid token)
    {
        try
        {
            using (var context = new ContextDataAccess())
            {
                foreach (var item in context.ActiveSessions.ToList())
                {
                    if (token == item.token) return item.idLogged;
                }

                return new Guid();
            }
        }
        catch (Exception)
        {
            throw new LostConnectionWithDataBase();
        }
    }

    public bool IsTokenActive(Guid token)
    {
        try
        {
            using (var context = new ContextDataAccess())
            {

                foreach (var item in context.ActiveSessions.ToList())
                {
                    if (token == item.token) return true;
                }
                return false;
            }
        }
        catch (Exception)
        {
            throw new LostConnectionWithDataBase();
        }
    }
}
}
