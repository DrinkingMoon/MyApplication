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
    /// SeasonDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class SeasonDetailView : UserControl
    {
        public SeasonDetailView()
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
                tbAutomaker.Text = Season.Automaker;
                tbCHN.Text = season.ChineseName;
                tbC.Text = season.Centigrade;
                tbW.Text = season.Weather;

                string uriStr = string.Format(@"/Img/{0}.jpg", season.Name);
                imgPhoto.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }
        }
    }
}
