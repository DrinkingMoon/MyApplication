using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication4
{
    class ReportTimeEventArgs : RoutedEventArgs
    {

        public DateTime ClickTime { get; set; }

        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }


    }
}
