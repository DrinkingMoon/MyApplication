using ClassLibrary1;
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

namespace WpfApplication3
{
    /// <summary>
    /// ValidationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ValidationWindow : Window
    {
        public ValidationWindow()
        {
            InitializeComponent();

            Binding binding = new Binding("Value") { Source = slider };
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.NotifyOnValidationError = true;
            binding.ValidationRules.Add(new RangeValidationRule(){ValidatesOnTargetUpdated = true});
            txt1.SetBinding(TextBox.TextProperty, binding);

            txt1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));
        }

        void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.txt1).Count > 0)
            {
                txt1.ToolTip = Validation.GetErrors(txt1)[0].ErrorContent.ToString();
            }
        }
    }
}
