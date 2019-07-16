using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Observer
{
    public interface IObserver
    {
        void Update(WeatherData weatherData);
    }
}
