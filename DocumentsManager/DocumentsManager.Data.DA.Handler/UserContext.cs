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
    public class UserContext
    {
        public List<User> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.UserRepository.Get().ToList();
            }
        }

        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }

        public void Add(User newUser)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.UserRepository.Insert(newUser);
            }
        }
        public bool Remove(User userToDelete)
        {
            return Remove(userToDelete.Id);
        }
        public bool Remove(Guid id)
        {
            bool deleted = false;
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.UserRepository.Delete(id);
                deleted = true;
            }
            return deleted;
        }
        public User GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.UserRepository.GetByID(id);
            }
        }
        public void Modify(User modifiedUser)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.UserRepository.Update(modifiedUser);
            }
        }
        public List<EditorUser> GetEditors() {
            List<EditorUser> editors = new List<EditorUser>();
            List<User> allUsers = new List<User>();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                allUsers = unitOfWork.UserRepository.Get().ToList();
            }
            foreach (User useri in allUsers)
            {
                if (useri is EditorUser)
                {
                    editors.Add(useri as EditorUser);
                }
            }
            return editors;
        }
        public List<AdminUser> GetAdmins()
        {
            List<AdminUser> admins = new List<AdminUser>();
            List<User> allUsers = new List<User>();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                allUsers = unitOfWork.UserRepository.Get().ToList();
            }
            foreach (User useri in allUsers)
            {
                if (useri is AdminUser)
                {
                    admins.Add(useri as AdminUser);
                }
            }
            return admins;
        }
        public bool Exists(User anUser)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.UserRepository.Exists(anUser.Id);
            }
        }
    }
}

