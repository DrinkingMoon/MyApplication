using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// TypeConverter.xaml 的交互逻辑
    /// </summary>
    public partial class TypeConverterWindow : Window
    {
        public TypeConverterWindow()
        {
            InitializeComponent();

            object propValue = ValueTypeConvert.GetValue<DateTime>("2019-1-1");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Human h = this.FindResource("human") as Human;

            if (h != null)
            {
                MessageBox.Show(h.Child.Name);
            }
        }
    }
}
