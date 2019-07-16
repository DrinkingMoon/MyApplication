using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Observer
{
    public class WeatherDataProvider:IObservable<WeatherDataStruct>
    {
        List<IObserver<WeatherDataStruct>> observers;

        public WeatherDataProvider()
        {
            observers = new List<IObserver<WeatherDataStruct>>();
        }

        public class UnSubscribe : IDisposable
        {
            List<IObserver<WeatherDataStruct>> _observers;
            IObserver<WeatherDataStruct> _observer;

            public UnSubscribe(List<IObserver<WeatherDataStruct>> observers, IObserver<WeatherDataStruct> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observers != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }

        public IDisposable Subscribe(IObserver<WeatherDataStruct> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new UnSubscribe(observers, observer);
        }

        public void SendWeatherData(Nullable<WeatherDataStruct> weather)
        {
            foreach (var observer in observers)
            {
                if (!weather.HasValue)
                {
                    observer.OnError(new WeatherDataUnkownException());
                }
                else
                {
                    observer.OnNext(weather.Value);
                }
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
            {
                observer.OnCompleted();
            }

            observers.Clear();
        }
    }

    public class WeatherDataUnkownException : Exception
    {
 
    }
}
