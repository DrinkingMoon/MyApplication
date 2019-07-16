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
    /// <summary>
    /// GridWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GridWindow : Window
    {
        public GridWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.beyandGrid.ShowGridLines = true;

            this.behindGrid.ColumnDefinitions.Add(new ColumnDefinition());
            this.behindGrid.ColumnDefinitions.Add(new ColumnDefinition());
            this.behindGrid.ColumnDefinitions.Add(new ColumnDefinition());
            this.behindGrid.ColumnDefinitions.Add(new ColumnDefinition());

            this.behindGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength() });
            this.behindGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength() });
            this.behindGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength() });
            this.behindGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength() });

            this.behindGrid.ShowGridLines = true;
        }
    }
}
