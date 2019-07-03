using MultiSelectExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MultiSelectExample.Context
{
    public class EntityContext: DbContext
    {
        public EntityContext()
            : base("name=ClassEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Profile> Profile { get; set; }

        public System.Data.Entity.DbSet<MultiSelectExample.ViewModel.ProfileViewModel> ProfileViewModels { get; set; }
    }
}