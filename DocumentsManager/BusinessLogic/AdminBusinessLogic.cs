using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;

namespace DocumentsManager.BusinessLogic
{
    public class AdminBusinessLogic :UserBusinessLogic, IAdminsBusinessLogic
    {
        public Guid Add(AdminUser admin)
        {
            admin.Id = Guid.NewGuid();
            UserContext uContext = new UserContext();
            if (IdRegistered(admin)) 
            {
                throw new ObjectAlreadyExistsException("Id");
            }
            if (EmailRegistered(admin)) 
            {
                throw new ObjectAlreadyExistsException("email");
            }
            if (UserNameRegistered(admin)) 
            {
                throw new ObjectAlreadyExistsException("username");
            }
            uContext.Add(admin);
            return admin.Id;
        }

        public bool Delete(Guid id)
        {
            UserContext uContext = new UserContext();
            AdminUser idUser = new AdminUser();
            idUser.Id = id;
            if (uContext.Exists(idUser))
            {
                return uContext.Remove(id);
            }
            throw new ObjectDoesNotExists(idUser);
        }

        public IEnumerable<AdminUser> GetAllAdmins()
        {
            UserContext uContext = new UserContext();
            return uContext.GetAdmins();
        }

        public AdminUser GetByID(Guid id)
        {
            AdminUser userToReturn = new AdminUser();
            UserContext uContext = new UserContext();
            User userToVerify = uContext.GetById(id);
            if (userToVerify is EditorUser)
            {
                throw new WrongUserType(userToReturn);
            }
            userToReturn = userToVerify as AdminUser;
            if (userToReturn == null)
            {
                throw new ObjectDoesNotExists(new EditorUser());
            }
            return userToReturn;
        }

        public bool Update(Guid id, AdminUser newAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
