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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication6
{
    /// <summary>
    /// SeasonUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class SeasonListItemView : UserControl
    {
        public SeasonListItemView()
        {
            InitializeComponent();
        }

        Season season;

        public Season Season
        {
            get => season;
            set
            {
                season = value;
                tbName.Text = season.Name;
                tbChineseName.Text = season.ChineseName;

                string uriStr = string.Format(@"/Img/ImgLogo/{0}.jpg", season.Automaker);
                imgLogo.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }
        }
    }
}
