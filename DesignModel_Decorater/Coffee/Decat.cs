using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    public class Decat : Beverage
    {
        public Decat()
        {
            description = "Decat";
        }

        public override double Cost()
        {
            return 1.05;
        }
    }
}
