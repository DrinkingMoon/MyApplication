using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    abstract class Duck
    {
        private IFlyAble flyBehavior;

        internal IFlyAble FlyBehavior
        {
            get { return flyBehavior; }
            set { flyBehavior = value; }
        }

        private IQuackAble quackBehavior;

        internal IQuackAble QuackBehavior
        {
            get { return quackBehavior; }
            set { quackBehavior = value; }
        }


        public void performQuack()
        {
            if (quackBehavior == null)
            {
                return;
            }

            quackBehavior.Quack();
        }

        public void performFly()
        {
            if (flyBehavior == null)
            {
                return;
            }

            flyBehavior.fly();
        }

        public abstract void display();

        public void Swim()
        {
            Console.WriteLine("鸭子在游泳");
        }
    }
}
