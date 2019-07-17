
using MyWpfMVVMApp.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpfMVVMApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //(new DataContext()).Database.CreateIfNotExists();

            MainWindow fMain = new MainWindow();
            fMain.ShowDialog();
        }
    }
}
