using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_MyBusiness
{
    class SNoChange : IUpdateStockAble
    {
        public void UpdateStock()
        {
            Console.WriteLine("不变更库存");
        }
    }
}
