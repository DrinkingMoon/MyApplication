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

namespace WpfApplication5
{

    public class ContentValueConvnert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string content = value.ToString();

            return content.Substring(4, content.Length - 4);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// CommandPrameterSample.xaml 的交互逻辑
    /// </summary>
    public partial class CommandPrameterSample : Window
    {
        public enum NewType
        {
            Teacher,
            Student
        }

        static readonly RoutedCommand newCommand = new RoutedCommand("New", typeof(ApplicationCommands));
        CommandBinding cb;
        Binding bd;

        public CommandPrameterSample()
        {
            InitializeComponent();

            cb = new CommandBinding(newCommand, delegate(object sender, ExecutedRoutedEventArgs e)
            {

                string name = nameTextBox.Text;

                switch (e.Parameter.ToString())
                {
                    case "Teacher":
                        listBoxNewItems.Items.Add(string.Format("New Teacher:{0}, ControName{1}", name, e.Source));
                        break;
                    case "Student":
                        listBoxNewItems.Items.Add(string.Format("New Student:{0}, ControName{1}", name, e.Source));
                        break;
                    default:
                        break;
                }
            });

            bd = new Binding();
            bd.Source = cb;

            ButtonSetBinding(gridRoot);
        }

        void ButtonSetBinding(DependencyObject control)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(control); i++)
            {
                DependencyObject dpo = VisualTreeHelper.GetChild(control, i);

                if (VisualTreeHelper.GetChildrenCount(dpo) == 0)
                {
                    if (dpo is Button)
                    {
                        Button btn = dpo as Button;

                        Binding binding = new Binding();
                        binding.Source = btn;
                        binding.Path = new PropertyPath("Content");
                        binding.Converter = new ContentValueConvnert();

                        btn.SetBinding(Button.CommandParameterProperty, binding);
                        //btn.Command = cb;
                    }
                }
                else
                {
                    ButtonSetBinding(dpo);
                }
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.nameTextBox.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }

            e.Handled = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string name = nameTextBox.Text;

            switch (e.Parameter.ToString())
            {
                case "Teacher":
                    listBoxNewItems.Items.Add(string.Format("New Teacher:{0}, ControName{1}", name, e.Source));
                    break;
                case "Student":
                    listBoxNewItems.Items.Add(string.Format("New Student:{0}, ControName{1}", name, e.Source));
                    break;
                default:
                    break;
            }
        }
    }
}
