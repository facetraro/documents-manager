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
    public class AdminUserContext
    {
        public List<AdminUser> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.AdminRepository.Get().ToList();
            }
        }

        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }

        public void Add(AdminUser newUser)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.AdminRepository.Insert(newUser);
            }
        }
        public void Remove(AdminUser userToDelete)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.AdminRepository.Delete(userToDelete);
            }
        }
        public void Remove(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.AdminRepository.Delete(id);
            }
        }
        public AdminUser GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.AdminRepository.GetByID(id);
            }
        }
        public void Modify(AdminUser modifiedUser)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.AdminRepository.Update(modifiedUser);
            }
        }
    }
}
