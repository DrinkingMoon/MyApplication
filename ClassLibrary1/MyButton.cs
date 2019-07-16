using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClassLibrary1
{
    public class MyButton : Button
    {

        Type _userTypeWindow;

        public Type UserTypeWindow
        {
            get { return _userTypeWindow; }
            set { _userTypeWindow = value; }
        }

        protected override void OnClick()
        {

            base.OnClick();

            if (_userTypeWindow == null)
            {
                return;
            }

            Window win = Activator.CreateInstance(this._userTypeWindow) as Window;

            if (win != null)
            {
                win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                win.ShowDialog();
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == Button.DataContextProperty)
            {
                _userTypeWindow = this.DataContext.GetType();
            }

        }
    }
}
