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

        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }

        public void Add(AdminUser newUser)
        {
            using (var context = new ContextDataAccess())
            {
                context.Admins.Add(newUser);
                context.SaveChanges();
            }
        }
        public void Remove(AdminUser newUser)
        {
            using (var context = new ContextDataAccess())
            {
                context.Admins.Remove(context.Admins.Find(newUser.Id));
                context.SaveChanges();
            }
        }

        public void Modify(AdminUser newUser)
        {
             using (var context = new ContextDataAccess())
            {
                Remove(context.Admins.Find(newUser.Id));
                Add(newUser);
            }
        }
    }
}
