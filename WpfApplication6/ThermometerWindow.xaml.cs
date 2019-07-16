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

namespace WpfApplication6
{
    /// <summary>
    /// ThermometerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ThermometerWindow : Window
    {
        public ThermometerWindow()
        {
            InitializeComponent();
            InitGrid1();
        }

        void InitGrid()
        {
            gridKD.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10) });

            for (int i = 0; i < 100; i++)
            {
                if (i%2 == 0)
                {
                    continue;
                }

                gridKD.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2) });

                //Rectangle rect1 = new Rectangle();
                //rect1.Width = 10;
                //rect1.Height = 1;
                //rect1.Fill = new SolidColorBrush(Colors.Black);

                Line rect1 = new Line();

                rect1.Width = 10;
                rect1.Fill = new SolidColorBrush(Colors.Black);

                Grid.SetRow(rect1, i);
                Grid.SetColumn(rect1, 0);

                gridKD.Children.Add(rect1);
            }
        }

        void InitGrid1()
        {
            gridKD.ShowGridLines = true;

            for (int i = 0; i < 5; i++)
            {
                gridKD.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 20; i++)
            {
                gridKD.RowDefinitions.Add(new RowDefinition());
            }

            Binding binding = new Binding();

            Random rd = new Random();

            foreach (Point pt in GetListArray())
            {
                Label lb = new Label();
                lb.Content = rd.Next(0, 100).ToString();

                Viewbox vb = new Viewbox();
                vb.Stretch = Stretch.Fill;
                vb.Child = lb;

                Grid.SetColumn(vb, (int)pt.X);
                Grid.SetRow(vb, (int)pt.Y);

                gridKD.Children.Add(vb);
            }
            
        }

        List<Point> GetListArray()
        {
            List<Point> result = new List<Point>();
            Random rd = new Random();

            while (result.Count < 15)
            {
                Point pt = new Point(rd.Next(0, 5), rd.Next(0, 20));

                if (!result.Contains(pt))
                {
                    result.Add(pt);
                }
            }

            return result;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            thermometer.Value = 50;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            thermometer.Value = 75;
        }
    }
}
