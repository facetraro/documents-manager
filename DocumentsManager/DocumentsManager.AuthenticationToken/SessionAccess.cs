using DocumentsManager.Exceptions;
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
                using (var context = new ContextSession())
                {

                    try
                    {
                        context.ActiveSessions.Add(newSession);
                        context.SaveChanges();
                        return newSession.token;
                    }
                    catch (Exception)
                    {
                        throw new LostConnectionWithDataBase();
                    }
                }
            }
            throw new UserAlreadyLogged();
        }
        public void Remove(Guid token)
        {
            using (var context = new ContextSession())
            {
                Session newSession = new Session();
                newSession.token = token;
                try
                {
                    context.ActiveSessions.Remove(context.ActiveSessions.Find(token));
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new LostConnectionWithDataBase();
                }
            }
        }
        public bool SessionAlreadyOpen(Guid id)
        {
            try
            {
                using (var context = new ContextSession())
                {

                    foreach (var item in context.ActiveSessions.ToList())
                    {
                        if (id == item.idLogged) return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                throw new LostConnectionWithDataBase();
            }
        }
        public void ClearAll()
        {
            try
            {
                using (var context = new ContextSession())
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
                using (var context = new ContextSession())
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
                using (var context = new ContextSession())
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
