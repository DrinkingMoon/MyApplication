using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication5
{
    public interface IView
    {
        bool IsChanged { get; set; }

        void SetBinding();

        void Refresh();

        void Save();

        void Clear();
    }

    public class ClearCommand:ICommand
    {

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter is IView view)
            {
                view.Clear();
            }
        }
    }

    public class MyCommandSource:UserControl, ICommandSource
    {

        public ICommand Command { get; set; }

        public object CommandParameter { get; set; }

        public System.Windows.IInputElement CommandTarget { get; set; }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (this.CommandTarget != null)
            {
                this.Command.Execute(this.CommandTarget);
            }
        }
    }
}
