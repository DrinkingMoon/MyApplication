using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (item.BaseType != typeof(Window) || item == this.GetType())
                {
                    continue;
                }

                Button btn = new Button();

                btn.Content = item.Name;
                btn.Height = 50;
                btn.DataContext = Activator.CreateInstance(item) as Window;
                btn.Click += btn_Click;

                this.stackPanel.Children.Add(btn);
            }
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window win = btn.DataContext as Window;

            if (win != null)
            {
                win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                win.ShowDialog();
            }
        }
    }
}
