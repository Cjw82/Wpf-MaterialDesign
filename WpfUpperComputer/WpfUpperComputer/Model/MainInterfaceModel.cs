using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using LiveCharts;

namespace WpfUpperComputer.Model
{
    public class MainInterfaceModel:ObservableObject
    {
        public MainInterfaceModel()
        {

        }
    }
    public class Device
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public string Description { get; set; }
    }
    public class DeviceInfo
    {
        public int DeviceCode { get; set; }
        public string DeviceTip { get; set; }
        public string ParaValue { get; set; }
    }
}
