using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_MyBusiness
{
    class FStoreKeeper:IExecFlowAble
    {
        public void ExecFlow()
        {
            Console.WriteLine("经过库管员");
        }
    }
}
