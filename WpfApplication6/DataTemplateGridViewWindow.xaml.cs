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

namespace WpfApplication6
{
    /// <summary>
    /// DataTemplateGridViewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateGridViewWindow : Window
    {
        public DataTemplateGridViewWindow()
        {
            InitializeComponent();
        }

        private void TbName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.OriginalSource as TextBox;

            ContentPresenter cp = tb.TemplatedParent as ContentPresenter;
            Student stu = cp.Content as Student;
            lstView.SelectedItem = stu;

            ListViewItem lvi = lstView.ItemContainerGenerator.ContainerFromItem(stu) as ListViewItem;

            CheckBox cb = FindVisualChild<CheckBox>(lvi);
            MessageBox.Show(cb.Name);

        }

        ChildType FindVisualChild<ChildType>(DependencyObject dpobj) where ChildType:DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dpobj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(dpobj, i);

                if (child != null && child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChild = FindVisualChild<ChildType>(child);

                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }

            return null;
        }

    }
}
