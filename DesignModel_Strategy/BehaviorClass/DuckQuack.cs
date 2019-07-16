using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    class DuckQuack : IQuackAble
    {
        public void Quack()
        {
            Console.WriteLine("实现鸭子呱呱叫");
        }
    }
}
