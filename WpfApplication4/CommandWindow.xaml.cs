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
    /// CommandWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CommandWindow : Window
    {
        public CommandWindow()
        {
            InitializeComponent();
            InitializeCommand();
        }

        RoutedCommand clearCmd = new RoutedCommand("Clear", typeof(CommandWindow));

        void InitializeCommand()
        {
            button1.Command = clearCmd;
            clearCmd.InputGestures.Add(new KeyGesture(Key.Enter));

            button1.CommandTarget = textBoxA;

            CommandBinding cb = new CommandBinding();
            cb.Command = clearCmd;
            cb.CanExecute += cb_CanExecute;
            cb.Executed += cb_Executed;

            stackPanel.CommandBindings.Add(cb);
        }

        void cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            textBoxA.Clear();

            e.Handled = true;
        }

        void cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxA.Text) && textBoxA.Text.Contains("Send"))
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }

            e.Handled = true;
        }
    }
}
