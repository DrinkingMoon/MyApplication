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
using System.Xml;

namespace WpfApplication3
{
    /// <summary>
    /// BindingXml.xaml 的交互逻辑
    /// </summary>
    public partial class BindingXml : Window
    {
        public BindingXml()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"E:\workspace\RowData.xml");

            XmlDataProvider xdp = new XmlDataProvider();
            //xdp.Document = doc;
            xdp.Source = new Uri(@"/File/RowData.xml", UriKind.Relative);
            xdp.XPath = @"/StudentList/Student";

            lstView.DataContext = xdp;
            lstView.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }
    }
}
