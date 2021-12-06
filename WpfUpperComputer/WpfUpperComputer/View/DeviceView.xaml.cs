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

namespace WpfUpperComputer.View
{
    /// <summary>
    /// DeviceView.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceView : UserControl
    {
        public DeviceView()
        {
            InitializeComponent();
            
        }
        private void ShowDeviceHellow()
        {
            this.SnackbarDevice.MessageQueue?.Enqueue(
                "设备展示界面",
                null,
                null,
                null,
                false,
                true,
                TimeSpan.FromSeconds(2));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowDeviceHellow();
        }
    }
}
