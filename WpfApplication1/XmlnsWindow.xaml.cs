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
using ClassLibrary1;

namespace WpfApplication1
{
    /// <summary>
    /// XmlnsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class XmlnsWindow : Window
    {
        public XmlnsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyButton mybutton = userCountrol1.FindName("customButton") as MyButton;
            mybutton.SetBinding(MyButton.DataContextProperty, new Binding() { Source = FindResource("showWindow") });
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }
    }
}
