using MyWpfMVVMApp.Entity;
using MyWpfMVVMApp.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfMVVMApp.Common
{
    public class MVVMDbContext : DataBaseContext
    {
        public MVVMDbContext() : base("MVVMDbContext")
        {
            //Database.SetInitializer<DbContext>(null);
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());

            //this.Configuration.AutoDetectChangesEnabled = false;
            //this.Configuration.ValidateOnSaveEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
