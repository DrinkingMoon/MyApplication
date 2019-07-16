using System;
using System.Collections.Generic;
using System.Data;
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
using System.Collections.ObjectModel;
using System.Reflection;
using ClassLibrary1;

namespace WpfApplication3
{
    /// <summary>
    /// BindingADODoNet.xaml 的交互逻辑
    /// </summary>
    public partial class BindingADODoNet : Window
    {
        public BindingADODoNet()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = Student.InitTable();

            lstBox.DisplayMemberPath = "Name";
            lstBox.ItemsSource = dt.DefaultView;

            //lstView.ItemsSource = dt.DefaultView;
            lstView.DataContext = dt;
            lstView.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }
    }
}
