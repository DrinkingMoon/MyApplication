using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Calculator
    {
        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        int _result;

        public int Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public Calculator()
        {
 
        }

        public Calculator(string arg1, string arg2)
        {
            double x = 0, y = 0, z = 0;

            if (double.TryParse(arg1, out x) && double.TryParse(arg2, out y))
            {
                z = x + y;

                _result = Convert.ToInt32(z);

            }
        }

        public string Add(string arg1, string arg2)
        {
            double x = 0, y = 0, z = 0;

            if (double.TryParse(arg1, out x) && double.TryParse(arg2, out y))
            {
                z = x + y;

                return z.ToString();
            }

            return "Input Error！";
        }

        public string Reduce(string arg1, string arg2)
        {
            double x = 0, y = 0, z = 0;

            if (double.TryParse(arg1, out x) && double.TryParse(arg2, out y))
            {
                z = x - y;

                return z.ToString();
            }

            return "Input Error！";
        }
    }
}
