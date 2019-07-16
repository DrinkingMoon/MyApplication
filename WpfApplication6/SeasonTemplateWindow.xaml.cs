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
    /// SeasonTemplateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SeasonTemplateWindow : Window
    {
        public SeasonTemplateWindow()
        {
            InitializeComponent();
            InitSeason();
        }

        void InitSeason()
        {
            List<Season> lstSeason = new List<Season>()
            {
                new Season(){Automaker = "Season", Name = "Spring", ChineseName = "春天", Centigrade = "23°", Weather = "Rain"},
                new Season(){Automaker = "Season", Name = "Summer", ChineseName = "夏天", Centigrade = "30°", Weather = "Sun"},
                new Season(){Automaker = "Season", Name = "Autumn", ChineseName = "秋天", Centigrade = "15°", Weather = "Cloudy"},
                new Season(){Automaker = "Season", Name = "Winter", ChineseName = "冬天", Centigrade = "0°", Weather = "Snow"},
            };

            lbSeason.ItemsSource = lstSeason;
        }
    }

    
}
