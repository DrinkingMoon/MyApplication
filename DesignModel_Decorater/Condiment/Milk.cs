using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    public class Milk : CondimentDecorater
    {
        public Milk(Beverage b) : base(b) 
        {
            this.DescriptionValue = "Milk";
            this.CostValue = .10;
        }

        public Milk()
        {
            this.DescriptionValue = "Milk";
            this.CostValue = .10;
        }
        public override string GetDescription()
        {
            return base._beverage.GetDescription() + ", " + this.DescriptionValue;
        }

        public override double Cost()
        {
            return base._beverage.Cost() + this.CostValue;
        }
    }
}
