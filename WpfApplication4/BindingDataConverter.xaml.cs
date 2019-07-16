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
using System.IO;
using ClassLibrary1;

namespace WpfApplication4
{
    /// <summary>
    /// BindingDataConverter.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDataConverter : Window
    {
        public BindingDataConverter()
        {
            InitializeComponent();
            
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Plane> obPlan = new ObservableCollection<Plane>();

            obPlan.Add(new Plane() { Category = Category.Bomber, Name = "B-1", State = State.Unknown });
            obPlan.Add(new Plane() { Category = Category.Bomber, Name = "B-2", State = State.Unknown });
            obPlan.Add(new Plane() { Category = Category.Fighter, Name = "F-22", State = State.Unknown });
            obPlan.Add(new Plane() { Category = Category.Fighter, Name = "Su-47", State = State.Unknown });
            obPlan.Add(new Plane() { Category = Category.Bomber, Name = "B-52", State = State.Unknown });
            obPlan.Add(new Plane() { Category = Category.Fighter, Name = "J-10", State = State.Unknown });

            Binding binding = new Binding();
            binding.Source = obPlan;
            binding.ValidationRules.Add(new WpfApplication4.PlanNameBindingRule());
            binding.Converter = new CategoryToSourceConvert();

            lstBox.ItemsSource = obPlan;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Plane p in lstBox.Items)
            {
                sb.AppendLine(string.Format("Category={0},Name={1},State={2}", p.Category, p.Name, p.State));
            }

            File.WriteAllText(@"D:\PlaneList.txt", sb.ToString());
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            sp.Background = Brushes.LightBlue;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            sp.Background = null;
        }
    }
}
