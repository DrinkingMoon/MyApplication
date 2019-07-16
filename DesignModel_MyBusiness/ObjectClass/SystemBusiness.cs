using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_MyBusiness
{
    abstract class SystemBusiness
    {
        IExecFlowAble execFlowBehavior;

        internal IExecFlowAble ExecFlowBehavior
        {
            get { return execFlowBehavior; }
            set { execFlowBehavior = value; }
        }

        IUpdateStockAble updateStockBehavior;

        internal IUpdateStockAble UpdateStockBehavior
        {
            get { return updateStockBehavior; }
            set { updateStockBehavior = value; }
        }


        public void UpdateStockInfo()
        {
            updateStockBehavior.UpdateStock();
        }

        public void ExecFlow()
        {
            execFlowBehavior.ExecFlow();
        }

        public abstract void RecordBusinessInfo();

    }
}
