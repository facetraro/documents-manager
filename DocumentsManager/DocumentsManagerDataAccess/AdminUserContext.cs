using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerDataAccess
{
    public class AdminUserContext
    {
        public List<AdminUser> GetLazy()
        {
            List<AdminUser> allLazy = new List<AdminUser>();
            using (var context = new ContextDataAccess())
            {
                allLazy = context.Admins.ToList();
            }
            return allLazy;
        }

        public void Add(AdminUser newUser)
        {
            using (var context = new ContextDataAccess())
            {
                context.Admins.Add(newUser);
                context.SaveChanges();
            }
        }
    }
}
