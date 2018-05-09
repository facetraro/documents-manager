using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;

namespace DocumentsManager.BusinessLogic
{
    public class AdminBusinessLogic : IAdminsBusinessLogic
    {
        public Guid Add(AdminUser admin)
        {
            throw new NotImplementedException();
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
