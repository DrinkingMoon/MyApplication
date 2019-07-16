using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Decorater
{
    public abstract class Beverage
    {
        private double _costValue;

        public double CostValue
        {
            get { return _costValue; }
            set { _costValue = value; }
        }

        private string _descriptionValue;

        public string DescriptionValue
        {
            get { return _descriptionValue; }
            set { _descriptionValue = value; }
        }
        


        protected string description = "Unkonw Beverage";

        public virtual string GetDescription()
        {
            return description;
        }

        public abstract double Cost();

        public void AddCondiment(CondimentDecorater condiment)
        {
            _descriptionValue += ", " + condiment.DescriptionValue;
            _costValue += condiment.CostValue;
        }


    }
}
