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

namespace WpfApplication1
{
    /// <summary>
    /// xNameWindow.xaml 的交互逻辑
    /// </summary>
    public partial class xNameWindow : Window
    {
        public xNameWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StackPanel panel = this.Content as StackPanel;

            if (panel == null)
            {
                return;
            }

            TextBox txt = panel.Children[0] as TextBox;

            if (string.IsNullOrEmpty(txt.Name))
            {
                txt.Text = "No Name!";
            }
            else
            {
                txt.Text = txt.Name;
            }
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Name))
            {
                textBox.Text = "No Name!";
            }
            else
            {
                textBox.Text = textBox.Name;
            }
        }

        private void ShowKeyContent_Click(object sender, RoutedEventArgs e)
        {
            this.textBox_Copy.Text = FindResource("myString").ToString();
        }
    }
}
