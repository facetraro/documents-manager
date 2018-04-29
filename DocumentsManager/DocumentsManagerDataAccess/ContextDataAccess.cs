using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerDataAccess
{
    public class ContextDataAccess : DbContext
    {
        public ContextDataAccess() : base("name=DocumentsManager") { }
        public DbSet<AdminUser> admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().HasKey(A => A.Id);
        }

        public List<AdminUser> GetLazy()
        {
            List<AdminUser> allLazy = new List<AdminUser>();
            allLazy.Add(new AdminUser());
            return allLazy;
        }

        public void Add(AdminUser newUser)
        {
           
        }
    }
}
