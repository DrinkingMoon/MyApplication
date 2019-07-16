using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "HouseBlend";

            this.DescriptionValue = "HouseBlend";
            this.CostValue = .89;
        }

        public override double Cost()
        {
            return .89;
        }
    }
}
