using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    public abstract class CondimentDecorater : Beverage
    {
        protected Beverage _beverage;

        public CondimentDecorater(Beverage b)
        {
            _beverage = b;
        }

        public CondimentDecorater()
        {
 
        }

        public abstract override string GetDescription();
    }
}
