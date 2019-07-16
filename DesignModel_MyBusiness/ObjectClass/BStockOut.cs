using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_MyBusiness
{
    class BStockOut : SystemBusiness
    {
        public BStockOut()
        {
            ExecFlowBehavior = new FStoreKeeper();
            UpdateStockBehavior = new SAdd();
        }

        public override void RecordBusinessInfo()
        {
            Console.WriteLine("记录出库单的明细信息");
        }
    }
}
