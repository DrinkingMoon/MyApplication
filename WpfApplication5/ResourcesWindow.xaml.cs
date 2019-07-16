using MahApps.Metro.Controls;
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
    /// <summary>
    /// ResourcesWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ResourcesWindow : Window
    {
        public ResourcesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string text = (string)this.FindResource("str");
            this.tb.Text = Resources["str"].ToString();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            Resources["tb1"] = new TextBlock() { Text = "天涯共此时" };
            Resources["tb2"] = new TextBlock() { Text = "天涯共此时" };

            tb3.Text = Properties.Resources.UserName;
            tb4.Text = Properties.Resources.Password;

            Uri imgUri = new Uri(@"Img/timg.jpg", UriKind.Relative);
            this.img.Source = new BitmapImage(imgUri);
        }
    }
}
