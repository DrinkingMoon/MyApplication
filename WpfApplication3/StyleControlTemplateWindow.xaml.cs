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
    /// StyleControlTemplateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StyleControlTemplateWindow : Window
    {
        public StyleControlTemplateWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox t = this.uc.Template.FindName("textBox1", this.uc) as TextBox;
            t.Text = "hello";
            StackPanel sp = t.Parent as StackPanel;
            (sp.Children[1] as TextBox).Text = "hello controltemplate";
            (sp.Children[2] as TextBox).Text = "find it";

            TextBlock tbl = this.tb.Template.FindName("textblck1", this.tb) as TextBlock;
            tbl.Text = "in textbox";
        }
    }
}
