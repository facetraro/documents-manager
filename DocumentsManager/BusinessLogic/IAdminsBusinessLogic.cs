using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public interface IAdminsBusinessLogic : IUsersBusinessLogic
    {
        IEnumerable<AdminUser> GetAllAdmins();
        AdminUser GetByID(Guid id);
        Guid Add(AdminUser admin);
        Guid Add(EditorUser admin);
        bool Delete(Guid id);
        bool Delete(User user);
        bool Update(Guid id, AdminUser newAdmin);
    }
}