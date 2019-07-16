using GalaSoft.MvvmLight.Messaging;
using MyWpfMVVMApp.Models;
using MyWpfMVVMApp.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWpfMVVMApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Messenger.Default.Register<object>(this, "MouseMove", obj => { MessageBox.Show(obj.ToString() + "挺不错的"); });

            Messenger.Default.Register<string>(this, "Submit", str=> { MessageBox.Show(str); });

        }

        void ChangeTextValue(Restaurant obj)
        {
            MainViewModel main = this.DataContext as MainViewModel;

            txt1.SetBinding(TextBox.TextProperty, new Binding("DataContext.Restaurant.Name") { Source = this });
        }
    }
}
