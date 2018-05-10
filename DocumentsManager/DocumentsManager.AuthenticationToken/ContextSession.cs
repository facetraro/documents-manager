using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.AuthenticationToken
{
    public class ContextSession : DbContext
    {
        public DbSet<Session> ActiveSessions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().HasKey(Session => Session.token);
        }
    }
}
