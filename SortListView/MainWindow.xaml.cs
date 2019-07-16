using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SortListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<DataItem> data = new ObservableCollection<DataItem>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = data;
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            data.Add(new DataItem()
            {
                ItemName = "Name" + Guid.NewGuid().ToString().Substring(0, 4),
                ItemValue = Guid.NewGuid().ToString().Substring(0, 4)
            });
        }
    }

    public class DataItem
    {
        public string ItemName { get; set; }
        public string ItemValue { get; set; }
    }
}
