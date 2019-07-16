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
using System.Collections;
using System.Globalization;

namespace WpfApplication6
{
    /// <summary>
    /// DataTemplateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateWindow : Window
    {
        public static string btnShowInfo = "DataTemplateWindow";

        public DataTemplateWindow()
        {
            InitializeComponent();
            //sp.DataContext = stringArrayArg;
            //btn1.SetBinding(Button.ContentProperty, new Binding("[5]") { Source = (FindResource("lstUnit") as ArrayList) });

            //btn1.Content = (FindResource("lstUnit") as ArrayList)[1];

            //cb.ItemTemplate = FindResource("UnitShow") as DataTemplate;
            //cb.ItemsSource = FindResource("ds") as ArrayList;
        }
    }
    public class Unit
    {
        public string Year { get; set; }

        public int Price { get; set; }

        public string[] stringArrayArg { get; set; } = new string[] { "A", "B", "C" };

    }

    public class StringArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string[] strings && parameter is string format)
            {
                try
                {
                    return string.Format(format, strings);
                }
                catch (Exception)
                {
                }
            }
            return string.Empty;
        }

        //Must implement this if Binding with Mode=TwoWay
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
