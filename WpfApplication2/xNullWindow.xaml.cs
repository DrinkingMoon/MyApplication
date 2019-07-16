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

namespace WpfApplication2
{
    public class Employee
    {
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }

    /// <summary>
    /// xNullWindow.xaml 的交互逻辑
    /// </summary>
    public partial class xNullWindow : Window
    {
        public static string WindowTitle = "山高月小";
        public static string ShowText { get { return "水落石出"; } }

        public xNullWindow()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
            {
                return;
            }

            DependencyObject lv1 = VisualTreeHelper.GetParent(btn);
            DependencyObject lv2 = VisualTreeHelper.GetParent(lv1);
            DependencyObject lv3 = VisualTreeHelper.GetParent(lv2);

            MessageBox.Show(string.Format("Level1:{0}  Level2:{1}  Level3:{2}  ", 
                lv1.GetType().ToString(), 
                lv2.GetType().ToString(), 
                lv3.GetType().ToString()));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> lstEmp = new List<Employee>()
            {
                new Employee(){Id=1, Name="Tim", Age=30},
                new Employee(){Id=2, Name="Tom", Age=25},
                new Employee(){Id=3, Name="Guo", Age=23},
                new Employee(){Id=4, Name="Yan", Age=18},
                new Employee(){Id=5, Name="Owen", Age=28},
                new Employee(){Id=6, Name="Victor", Age=25}
            };

            lstEmployee.DisplayMemberPath = "Name";
            lstEmployee.SelectedValue = "Id";
            lstEmployee.ItemsSource = lstEmp;
        }
    }
}
