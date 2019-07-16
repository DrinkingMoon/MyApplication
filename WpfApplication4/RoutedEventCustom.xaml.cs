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

namespace WpfApplication4
{
    /// <summary>
    /// RoutedEventCustom.xaml 的交互逻辑
    /// </summary>
    public partial class RoutedEventCustom : Window
    {
        public RoutedEventCustom()
        {
            InitializeComponent();
            this.AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonClick));
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string strOriginalSource = string.Format("VisualTree start point:{0}, type is {1}", 
                (e.OriginalSource as FrameworkElement).Name, e.OriginalSource.GetType().Name);

            string strSource = string.Format("LogicalTree start potin:{0}, type is {1}",
                (e.Source as FrameworkElement).Name, e.Source.GetType().Name);

            MessageBox.Show(strOriginalSource + "\r\n" + strSource);
        }

        private void ReportTimeHandler(object sender, ReportTimeEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;

            string timeStr = e.ClickTime.ToLongTimeString();
            string content = string.Format("{0}到达{1}", timeStr, element.Name);

            this.lstBox.Items.Add(content);
        }
    }
}
