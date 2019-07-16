using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    class FlyWithWings : IFlyAble
    {
        public void fly()
        {
            Console.WriteLine("实现鸭子飞行");
        }
    }
}
