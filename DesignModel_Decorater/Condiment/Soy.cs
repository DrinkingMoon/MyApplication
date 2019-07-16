using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    public class Soy : CondimentDecorater
    {
        new Beverage _beverage;

        public Soy(Beverage b)
        {
            _beverage = b;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Soy";
        }

        public override double Cost()
        {
            return _beverage.Cost() + .15;
        }
    }
}
