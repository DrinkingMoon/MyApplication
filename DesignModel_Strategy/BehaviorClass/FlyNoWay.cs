using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    class FlyNoWay:IFlyAble
    {
        public void fly()
        {
            Console.WriteLine("什么都不做，不会飞");
        }
    }
}
