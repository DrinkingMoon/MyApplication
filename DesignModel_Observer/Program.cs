using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FristWay

            //WeatherDataProvider provider = new WeatherDataProvider();

            //WeatherDataReport report1 = new WeatherDataReport("长沙");
            //report1.Subscriber(provider);
            //WeatherDataReport report2 = new WeatherDataReport("株洲");
            //report2.Subscriber(provider);
            //WeatherDataReport report3 = new WeatherDataReport("湘潭");
            //report3.Subscriber(provider);
            //Console.WriteLine("=========================================>");

            //provider.SendWeatherData(new WeatherDataStruct() { Temperature = 23, Humidty = 24, Perssure = 25 });
            //Console.WriteLine("=========================================>");

            //report1.UnSubscriber();
            //Console.WriteLine("=========================================>");

            //provider.SendWeatherData(new WeatherDataStruct() { Temperature = 33, Humidty = 34, Perssure = 35 });
            //Console.WriteLine("=========================================>");

            //provider.EndTransmission();
            //Console.WriteLine("=========================================>");

            #endregion

            #region SecondWay

            WeatherData weatherData = new WeatherData() { Temperature = 22, Humidty = 23, Perssure = 24 };
            CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay("长沙", weatherData);

            weatherData.Perssure = 99;

            #endregion

            Console.ReadKey();
        }
    }
}
