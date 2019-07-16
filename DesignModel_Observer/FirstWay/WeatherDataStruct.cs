using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DesignModel_Observer
{
    public struct WeatherDataStruct
    {
        float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        float humidty;

        public float Humidty
        {
            get { return humidty; }
            set { humidty = value; }
        }
        float perssure;

        public float Perssure
        {
            get { return perssure; }
            set { perssure = value; }
        }
    }
}
