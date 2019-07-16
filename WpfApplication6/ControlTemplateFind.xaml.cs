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
using WpfApplication2;

namespace WpfApplication6
{
    /// <summary>
    /// ControlTemplateFind.xaml 的交互逻辑
    /// </summary>
    public partial class ControlTemplateFind : Window
    {
        public ControlTemplateFind()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb = uc.Template.FindName("txt1", uc) as TextBox;
            DatePicker dp = uc.Template.FindName("dp1", uc) as DatePicker;

            dp.Text = DateTime.Now.AddYears(1).ToString();

            StackPanel sp = tb.Parent as StackPanel;
            tb.Text = "Hello Wpf";
            (sp.Children[1] as TextBox).Text = "Hello ControlTemplate";
            (sp.Children[2] as TextBox).Text = "I can find you!";

            Button btnTemp = uc.Template.FindName("bt2", uc) as Button;

            Image img = btnTemp.Content as Image;
                //uc.Template.FindName("img1", uc) as Image;

            System.Drawing.Bitmap bitmap = WpfApplication2.Properties.Resources.xiaolian;
            IntPtr ip = bitmap.GetHbitmap();//从GDI+ Bitmap创建GDI位图对象

            BitmapSource bitmapSource = 
                System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, Int32Rect.Empty,
            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            img.Source = bitmapSource;

        }
    }
}
