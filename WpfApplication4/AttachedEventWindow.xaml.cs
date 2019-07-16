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

namespace WpfApplication4
{
    /// <summary>
    /// AttachedEventWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AttachedEventWindow : Window
    {
        public AttachedEventWindow()
        {
            InitializeComponent();
            gridMain.AddHandler(Student.NameChangeEvent, new RoutedEventHandler(StudentNameChangeHandler));
        }

        private void StudentNameChangeHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Student).Id.ToString());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student() { Id = 101, Name = "Tim" };
            stu.Name = "Tom";
            RoutedEventArgs arg = new RoutedEventArgs(Student.NameChangeEvent, stu);
            button1.RaiseEvent(arg);
        }
    }
}
