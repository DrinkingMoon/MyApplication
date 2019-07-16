using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfApplication3
{
    /// <summary>
    /// BindingObjectDataProviderWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BindingObjectDataProviderWindow : Window
    {
        ObjectDataProvider odp = new ObjectDataProvider();

        Calculator cl = new Calculator();

        Student stu = new Student();

        Human hm = new Human();

        public BindingObjectDataProviderWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //SetBinding();

            //cl.Name = "Roy";
            txt1.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = hm, Mode = BindingMode.TwoWay });
            txt4.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu, Mode = BindingMode.TwoWay });
        }

        void SetBinding()
        {
            //odp = new ObjectDataProvider();

            //odp.ObjectInstance = cl;
            //odp.MethodName = "Add";
            //odp.MethodParameters.Add("0");
            //odp.MethodParameters.Add("0");

            //Binding bindingX = new Binding("MethodParameters[0]")
            //{
            //    Source = odp,
            //    BindsDirectlyToSource = true,
            //    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            //};

            //txt1.SetBinding(TextBox.TextProperty, bindingX);

            //Binding bindingY = new Binding("MethodParameters[1]")
            //{
            //    Source = odp,
            //    BindsDirectlyToSource = true,
            //    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            //};

            //txt2.SetBinding(TextBox.TextProperty, bindingY);

            //Binding bindingZ = new Binding(".")
            //{
            //    Source = odp
            //};

            //txt3.SetBinding(TextBox.TextProperty, bindingZ);
            txt4.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = cl, Mode = BindingMode.TwoWay });
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            hm.Name += "Roy";
            stu.Name += "Roy";

            //odp = new ObjectDataProvider();

            //odp.ObjectType = typeof(Calculator);
            //odp.ObjectInstance = new Calculator("300", "400");
            //odp.MethodName = "Add";
            //odp.MethodParameters.Add("100");
            //odp.MethodParameters.Add("200");

            //MessageBox.Show(odp.Data.ToString());

            //txt4.SetBinding(TextBox.TextProperty, new Binding("Result") {  Source = odp });


            //odp.ConstructorParameters.Add("500");
            //odp.ConstructorParameters.Add("600");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            BindingOperations.ClearAllBindings(txt1);
            BindingOperations.ClearAllBindings(txt2);
            BindingOperations.ClearAllBindings(txt3);

            odp = new ObjectDataProvider();

            odp.ObjectType = typeof(Calculator);
            odp.ConstructorParameters.Add("500");
            odp.ConstructorParameters.Add("600");


            odp.MethodName = "Reduce";
            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");

            Binding bindingX = new Binding("MethodParameters[0]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            txt1.SetBinding(TextBox.TextProperty, bindingX);

            Binding bindingY = new Binding("MethodParameters[1]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            txt2.SetBinding(TextBox.TextProperty, bindingY);

            Binding bindingZ = new Binding(".")
            {
                Source = odp
            };

            txt3.SetBinding(TextBox.TextProperty, bindingZ);
        }

        private void Cm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MultiBinding mb = new MultiBinding();

            mb.Bindings.Add(new Binding("Text") { ElementName = "txt1" });
            mb.Bindings.Add(new Binding("Text") { ElementName = "txt2" });

            mb.Converter = new MultiBindingConverter();
            mb.ConverterParameter = (cm.SelectedItem as ComboBoxItem).Content.ToString();
            txt3.SetBinding(TextBox.TextProperty, mb);
        }
    }

    public class MultiBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double a, b;

            if (!Double.TryParse(values[0].ToString(), out a))
            {
                a = 0;
            }

            if (!Double.TryParse(values[1].ToString(), out b))
            {
                b = 0;
            }

            if (parameter.ToString() == "Add")
            {
                return (a + b).ToString();
            }
            else if(parameter.ToString() == "Reduce")
            {
                return (a - b).ToString();
            }
            else
            {
                return null;
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
