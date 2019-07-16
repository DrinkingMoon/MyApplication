using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication4
{
    /// <summary>
    /// MultiBindingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MultiBindingWindow : Window
    {
        public MultiBindingWindow()
        {
            InitializeComponent();
            SetMultiBinding();
        }

        void SetMultiBinding()
        {
            Binding b1 = new Binding("Text") { Source = txt1 };
            Binding b2 = new Binding("Text") { Source = txt2 };
            Binding b3 = new Binding("Text") { Source = txt3 };
            Binding b4 = new Binding("Text") { Source = txt4 };

            MultiBinding mb = new MultiBinding() { Mode = BindingMode.OneWay };

            mb.Bindings.Add(b1);
            mb.Bindings.Add(b2);
            mb.Bindings.Add(b3);
            mb.Bindings.Add(b4);

            mb.Converter = new LogonMultiBindingConverter();

            btn1.SetBinding(Button.IsEnabledProperty, mb);
        }
    }

    class LogonMultiBindingConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!values.Cast<string>().Any(text=>string.IsNullOrEmpty(text))
                && values[0].ToString() == values[1].ToString()
                && values[2].ToString() == values[3].ToString())
            {
                return true;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
