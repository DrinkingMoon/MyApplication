using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    class Squack:IQuackAble
    {
        public void Quack()
        {
            Console.WriteLine("橡皮鸭子吱吱叫");
        }
    }
}
