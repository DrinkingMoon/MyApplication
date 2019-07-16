using ClassLibrary1;
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
    /// BindingApplication1.xaml 的交互逻辑
    /// </summary>
    public partial class BindingApplication1 : Window
    {
        //Binding binding;

        Student stu = new Student();

        public BindingApplication1()
        {
            InitializeComponent();

            //binding = new Binding();
            //binding.Path = new PropertyPath("Name");
            //binding.Source = stu;

            //BindingOperations.SetBinding(txt1, TextBox.TextProperty, binding);

            txt1.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu, Mode = BindingMode.TwoWay });

            //BindingOperations.SetBinding(stu, Student.DepNameProperty, new Binding("Text") { Source = txt4 , Mode = BindingMode.TwoWay});

            stu.SetBinding(Student.DepNameProperty, new Binding("Text") { Source = txt4, Mode = BindingMode.TwoWay });
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += "Name";
            txt4.Text += "DepName";
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            stu.Name += "Name";
            stu.DepName += "DepName";
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            tb1.Text = "";

            tb1.Text += "StuName      Value:  " + stu.Name + "\r\n";
            tb1.Text += "StuName      TextBox:" + txt1.Text + "\r\n";
            tb1.Text += "StuDepName Value:  " + stu.DepName + "\r\n";
            tb1.Text += "StuDepName TextBox:" + txt4.Text + "\r\n";
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            stu.Name = "";
            stu.DepName = "";
            txt1.Text = "";
            txt4.Text = "";
        }
    }
}
