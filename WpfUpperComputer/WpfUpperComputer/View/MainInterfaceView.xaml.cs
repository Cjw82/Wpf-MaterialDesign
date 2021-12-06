using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Threading;
using WpfUpperComputer.Model;
using WpfUpperComputer.ViewModel;

namespace WpfUpperComputer.View
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        private DispatcherTimer _timer = null;
        private readonly Random _random = new Random();
        //private MainInterfaceViewModel MainInterfaceViewModel = null;
        public MainView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //MainInterfaceViewModel = this.DataContext as MainInterfaceViewModel;
            RanderData();
        }
        private void RanderData()
        {

            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler((sender, e) =>
            {
                var values = new ChartValues<int>();
                for (int i = 0; i < 13; i++)
                {
                    values.Add(_random.Next(0, 1000));
                }
                this.cl.Values = values;
            });
            //_timer.Interval = new TimeSpan(10000000);
            _timer.Interval = new TimeSpan(0, 0, 5);
            _timer.IsEnabled = true;
            _timer.Start();
        }

        private void ListFlipper_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.listFlipper.IsFlipped)
            {
                var gird = e.OriginalSource as Grid;
                if (gird == null) return;
                var deviceInfo = gird.DataContext as DeviceInfo;
                if (deviceInfo != null)
                {
                    showSelectItem.Tip = deviceInfo.DeviceTip;
                    showSelectItem.TipTextValue = deviceInfo.ParaValue;
                }
            }
            this.listFlipper.IsFlipped = !this.listFlipper.IsFlipped;
        }

        
        private void listFlipper2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.listFlipper2.IsFlipped = !this.listFlipper2.IsFlipped;
          
        }
    }
}
