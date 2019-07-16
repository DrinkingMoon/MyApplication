using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    class MallardDuck : Duck
    {
        public MallardDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new MuteQuack();
        }

        public override void display()
        {
            Console.WriteLine("外观是绿头的鸭子");
        }
    }
}
