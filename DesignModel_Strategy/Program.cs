using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck duck = new MallardDuck();
            duck.performFly();
            duck.performQuack();

            duck.FlyBehavior = new FlyWithWings();
            duck.FlyBehavior.fly();

            Console.ReadKey();
        }
    }
}
