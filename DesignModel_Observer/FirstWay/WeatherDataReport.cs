using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Observer
{
    public class WeatherDataReport:IObserver<WeatherDataStruct>
    {
        IDisposable unsubscriber;

        string instName;

        public string InstName
        {
            get { return instName; }
            set { instName = value; }
        }

        public WeatherDataReport(string name)
        {
            instName = name;
        }

        public virtual void Subscriber(IObservable<WeatherDataStruct> provider)
        {
            if (provider != null)
            {
                Console.WriteLine(string.Format("【{0}】订阅了天气数据的传输", instName));
                unsubscriber = provider.Subscribe(this);
            }
        }

        public virtual void UnSubscriber()
        {
            Console.WriteLine(string.Format("【{0}】取消了天气数据的订阅传输", instName));
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Console.WriteLine(string.Format("天气数据已经向【{0}】传输完毕", instName));
            UnSubscriber();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(string.Format("在向【{0}】传输天气数据时，发生错误：{1}", instName, error.Message));
        }

        public void OnNext(WeatherDataStruct value)
        {
            Console.WriteLine(string.Format("【{0}】，温度：{1} ， 湿度：{2} ，气压：{3}", instName, value.Temperature, value.Humidty, value.Perssure));
        }
    }
}
