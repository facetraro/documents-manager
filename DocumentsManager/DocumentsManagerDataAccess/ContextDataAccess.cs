﻿using DocumentsMangerEntities;
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
        public DbSet<AdminUser> Admins { get; set; }
        public DbSet<EditorUser> Editors { get; set; }
        public DbSet<StyleClass> Styles { get; set; }
        public DbSet<StyleAttribute> Attributes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().HasKey(A => A.Id);
            modelBuilder.Entity<EditorUser>().HasKey(E => E.Id);
            modelBuilder.Entity<StyleClass>().HasKey(S => S.Id);
            modelBuilder.Entity<StyleAttribute>().HasKey(S => S.Id);
        }
    }
}