using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Observer
{
    public class CurrentConditionDisplay :IObserver, IDisplayElement
    {
        string _insName;

        ISubject _subject;

        WeatherData _weatherData;

        public CurrentConditionDisplay(string name, ISubject subject)
        {
            _insName = name;
            _subject = subject;
            _subject.RegisterObserver(this);
        }

        public void Update(WeatherData weatherData)
        {
            _weatherData = weatherData;
            Display();
        }

        public void Display()
        {
            Console.WriteLine(string.Format("【{0}】，温度：{1} ， 湿度：{2} ，气压：{3}", _insName, _weatherData.Temperature, _weatherData.Humidty, _weatherData.Perssure));
        }
    }
}
