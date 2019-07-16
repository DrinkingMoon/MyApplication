using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel_Observer
{
    public class WeatherData:ISubject, INotifyPropertyChanged
    {
        ArrayList observers;

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public WeatherData()
        {
            observers = new ArrayList();
        }


        float temperature;

        public float Temperature
        {
            get { return temperature; }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                    NotifyObservers();
                    OnPropertyChanged();
                }
            }
        }
        float humidty;

        public float Humidty
        {
            get { return humidty; }
            set
            {
                if (humidty != value)
                {
                    humidty = value;
                    NotifyObservers();
                    OnPropertyChanged();
                }
            }
        }
        float perssure;

        public float Perssure
        {
            get { return perssure; }
            set
            {
                if (perssure != value)
                {
                    perssure = value;
                    NotifyObservers();
                    OnPropertyChanged();
                }
            }
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            int index = observers.IndexOf(o);

            if (index >= 0)
            {
                observers.RemoveAt(index);
            }
        }

        public void NotifyObservers()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                IObserver observer = observers[i] as IObserver;
                observer.Update(this);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
