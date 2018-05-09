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
            throw new NotImplementedException();
        }

        public IEnumerable<AdminUser> GetAllAdmins()
        {
            UserContext uContext = new UserContext();
            return uContext.GetAdmins();
        }

        public AdminUser GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, AdminUser newAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
