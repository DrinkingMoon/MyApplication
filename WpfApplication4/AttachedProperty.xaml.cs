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
    /// AttachedProperty.xaml 的交互逻辑
    /// </summary>
    public partial class AttachedProperty : Window
    {
        public AttachedProperty()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Human hm = new Human();

            School.SetGrade(hm, 6);
            int grade = School.GetGrade(hm);

            MessageBox.Show(grade.ToString());
        }
    }
}
