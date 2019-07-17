using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfMVVMApp.Common
{
    public class MVVMRepository :  RepositoryBase
    {
        public MVVMRepository() : base(new MVVMDbContext())
        {
        }
    }
}
