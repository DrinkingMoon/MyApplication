using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_MyBusiness
{
    class BInspection : SystemBusiness
    {
        public BInspection()
        {
            ExecFlowBehavior = new FInspection();
            UpdateStockBehavior = new SNoChange();
        }

        public override void RecordBusinessInfo()
        {
            Console.WriteLine("记录检验单的明细信息");
        }
    }
}
