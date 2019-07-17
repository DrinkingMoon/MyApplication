using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfMVVMApp.Common
{
    public class DataBaseInitializer : IDatabaseInitializer<MVVMDbContext>
    {
        public void InitializeDatabase(MVVMDbContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
