using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_MyBusiness
{
    class BStockIn:SystemBusiness
    {
        public BStockIn()
        {
            ExecFlowBehavior = new FStoreKeeper();
            UpdateStockBehavior = new SAdd();
        }

        public override void RecordBusinessInfo()
        {
            Console.WriteLine("记录入库单的明细信息");
        }
    }
}
