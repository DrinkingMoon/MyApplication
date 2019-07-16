using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApplication3
{
    /// <summary>
    /// BindingObservableCollectionWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BindingObservableCollectionWindow : Window
    {
        ObservableCollection<Student> obStu = Student.InitObCollection();

        public BindingObservableCollectionWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstBox.ItemsSource = obStu;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            obStu.Add(new Student() { Id = 6, Age = 29, Name = "Wellen" });
        }
    }
}
