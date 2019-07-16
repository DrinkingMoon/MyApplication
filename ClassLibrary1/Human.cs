using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary1
{
    [TypeConverter(typeof(StringToHumanTypeConverter))]
    public class Human :DependencyObject, INotifyPropertyChanged
    {
        string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        Human _child;

        public Human Child
        {
            get { return _child; }
            set { UpdateProper(ref _child, value); }
        }

        List<string> _lstNumber;

        public List<string> LstNumber
        {
            get { return _lstNumber; }
            set { UpdateProper(ref _lstNumber, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected void UpdateProper<T>(ref T properValue, T newValue, [CallerMemberName] string properName = "")
        {
            if (object.Equals(properValue, newValue))
                return;

            properValue = newValue;

            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(properName));
            }
        }
    }

    public class StringToHumanTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                Human h = new Human
                {
                    Name = value as string
                };
                return h;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }

    public static class ValueTypeConvert
    {
        public static T GetValue<T>(string value) where T : struct
        {
            var td = TypeDescriptor.GetConverter(typeof(T));
            return (T)td.ConvertFromInvariantString(value);
        }

        //public static void SetValue<T>(this Configurator config, string key, T value) where T : struct
        //{
        //    var td = TypeDescriptor.GetConverter(typeof(T));
        //    var tepValue = td.ConvertToInvariantString(value);
        //    config[key] = tepValue;
        //}
    }
}
