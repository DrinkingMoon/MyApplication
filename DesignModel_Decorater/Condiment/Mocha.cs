using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    public class Mocha : CondimentDecorater
    {
        public Mocha(Beverage b) : base(b) { }

        public override string GetDescription()
        {
            return base._beverage.GetDescription() + ", Mocha";
        }

        public override double Cost()
        {
            return base._beverage.Cost() + .20;
        }
    }
}
