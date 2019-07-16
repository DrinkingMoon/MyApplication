using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_MyBusiness
{
    class FInspection : IExecFlowAble
    {
        public void ExecFlow()
        {
            Console.WriteLine("经过质检员");
        }
    }
}
