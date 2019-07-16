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

namespace WpfApplication4
{
    /// <summary>
    /// RoutedEventWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RoutedEventWindow : Window
    {
        public RoutedEventWindow()
        {
            InitializeComponent();
            //this.AddHandler(Control.MouseDoubleClickEvent, new RoutedEventHandler(MouseClick));
            //this.AddHandler(Control.MouseUpEvent, new RoutedEventHandler(MouseClick));
            //this.AddHandler(Button.ClickEvent, new RoutedEventHandler(MouseClick));

            canvasLeft.AddHandler(Control.MouseUpEvent, new RoutedEventHandler(MouseClick1));
            canvasLeft.AddHandler(Button.ClickEvent, new RoutedEventHandler(MouseClick1));
        }

        private void MouseClick1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.Source as FrameworkElement).Name);
            //e.Handled = true;
        }

        void MouseClick(object sender, RoutedEventArgs e)
        {
            string strOriginalSource = string.Format("VisualTree start point:{0}, type is {1}",
                (e.OriginalSource as FrameworkElement).Name, e.OriginalSource.GetType().Name);

            string strSource = string.Format("LogicalTree start potin:{0}, type is {1}",
                (e.Source as FrameworkElement).Name, e.Source.GetType().Name);

            MessageBox.Show(strOriginalSource + "\r\n" + strSource);
        }
    }
}
