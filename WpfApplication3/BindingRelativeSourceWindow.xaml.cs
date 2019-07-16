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

namespace WpfApplication3
{
    /// <summary>
    /// BindingRelativeSourceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BindingRelativeSourceWindow : Window
    {
        public BindingRelativeSourceWindow()
        {
            InitializeComponent();

            //RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            //rs.AncestorLevel = 1;
            //rs.AncestorType = typeof(Grid);

            //Binding binding = new Binding("Name") { RelativeSource = rs };
            //txt1.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
