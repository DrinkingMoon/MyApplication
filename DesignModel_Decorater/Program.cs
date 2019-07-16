using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage bev = new Espresso();
            Console.WriteLine(bev.GetDescription() + " $" + bev.Cost());
            Console.WriteLine("=========================================>");

            Beverage bev2 = new DarkRoast();
            bev2 = new Mocha(bev2);
            bev2 = new Soy(bev2);
            bev2 = new Whip(bev2);
            Console.WriteLine(bev2.GetDescription() + " $" + bev2.Cost());
            Console.WriteLine("=========================================>");

            Beverage bev3 = new HouseBlend();
            bev3.AddCondiment(new Milk());
            Console.WriteLine(bev3.DescriptionValue + " $" + bev3.CostValue);
            Console.WriteLine("=========================================>");

            Console.ReadKey();
        }
    }
}
