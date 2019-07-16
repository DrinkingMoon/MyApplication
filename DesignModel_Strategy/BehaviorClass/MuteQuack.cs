using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Strategy
{
    class MuteQuack:IQuackAble
    {
        public void Quack()
        {
            Console.WriteLine("什么都不做，不会叫");
        }
    }
}
