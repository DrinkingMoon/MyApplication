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
using System.Collections.ObjectModel;
using System.Data;
using System.Xml.Linq;
using ClassLibrary1;

namespace WpfApplication3
{
    /// <summary>
    /// BindingLinqWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BindingLinqWindow : Window
    {
        ObservableCollection<Student> obStu = Student.InitObCollection();

        public BindingLinqWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            lstView.ItemsSource = from stu in obStu where stu.Name.StartsWith("T") select stu;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = Student.InitTable();

            //obStu = new ObservableCollection<Student>((from row in dt.Rows.Cast<DataRow>()
            //                                           where row["Name"].ToString().StartsWith("T")
            //                                           select new Student()
            //                                           {
            //                                               Id = Convert.ToInt32(row["Id"]),
            //                                               Name = Convert.ToString(row["Name"]),
            //                                               Age = Convert.ToInt32(row["Age"])
            //                                           }).ToList());

            lstView.ItemsSource = from row in dt.Rows.Cast<DataRow>()
                                  where Convert.ToUInt32(row["Age"]) >= 26
                                  select new Student()
                                  {
                                      Id = Convert.ToInt32(row["Id"]),
                                      Name = Convert.ToString(row["Name"]),
                                      Age = Convert.ToInt32(row["Age"])
                                  };
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            XDocument xdoc =
                XDocument.Load(@"E:\WorkSpace\C#\Visual Studio 2013\Projects\MyWpfApplication\WpfApplication3\RowData.xml");

            lstView.ItemsSource = from xml in xdoc.Descendants("Student")
                                  where Convert.ToInt32(xml.Attribute("Age").Value) <= 30
                                  select new Student()
                                  {
                                      Id = Convert.ToInt32(xml.Attribute("Id").Value),
                                      Name = Convert.ToString(xml.Attribute("Name").Value),
                                      Age = Convert.ToInt32(xml.Attribute("Age").Value)
                                  };
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            foreach (Student stu in obStu)
            {
                stu.Name = "Roy";
            }

            //lstView.ItemsSource = from stu in obStu where stu.Name.StartsWith("T") select stu;
        }
    }
}
