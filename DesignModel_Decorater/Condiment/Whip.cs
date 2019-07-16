using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    public class Whip : CondimentDecorater
    {
        public Whip(Beverage b) : base(b) { }

        public override string GetDescription()
        {
            return base._beverage.GetDescription() + ", Whip";
        }

        public override double Cost()
        {
            return base._beverage.Cost() + .10;
        }
    }
}
