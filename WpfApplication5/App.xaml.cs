using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication5
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ResourcesWindow fLogin = new ResourcesWindow();

            MainWindow fMain = new MainWindow();
            fLogin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (fLogin.ShowDialog() == true)
            {
                fMain.Show();
            }
            else
            {
                fMain.Close();
            }
        }
    }
}
