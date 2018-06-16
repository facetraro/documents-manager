using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ProxyInterfaces
{
    public interface IAdminsBusinessLogic : IUserBusinessLogic
    {
        IEnumerable<AdminUser> GetAllAdmins(Guid tokenId);
        AdminUser GetAdminByID(Guid id, Guid tokenId);
        Guid AddAdmin(AdminUser admin, Guid tokenId);
        Guid AddEditor(EditorUser editor, Guid tokenId);
        bool DeleteAdmin(Guid id, Guid tokenId);
        bool DeleteAdmin(User user, Guid tokenId);
        bool UpdateAdmin(Guid id, AdminUser newAdmin, Guid tokenId);
    }
}
