using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    class RedHeadDuck : Duck
    {
        public override void display()
        {
            Console.WriteLine("外观是红头的鸭子");
        }
    }
}
