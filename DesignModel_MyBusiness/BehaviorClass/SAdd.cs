using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_MyBusiness
{
    class SAdd:IUpdateStockAble
    {
        public void UpdateStock()
        {
            Console.WriteLine("增加库存");
        }
    }
}
