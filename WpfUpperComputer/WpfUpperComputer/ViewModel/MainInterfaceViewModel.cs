using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfUpperComputer.Model;
namespace WpfUpperComputer.ViewModel
{
    public class MainInterfaceViewModel:ViewModelBase
    {
        public MainInterfaceModel MainInterfaceModel { get; set; }
        public List<Device> Devices { get; set; }

        public List<DeviceInfo> DeviceInfos { get; set; }
        public MainInterfaceViewModel()
        {
            MainInterfaceModel = new MainInterfaceModel();
            DeviceInfos = new List<DeviceInfo>()
            {
                new DeviceInfo(){DeviceCode=1,DeviceTip="温度",ParaValue="23"},
                new DeviceInfo(){DeviceCode=1,DeviceTip="湿度",ParaValue="12" },
                new DeviceInfo(){DeviceCode=1,DeviceTip="质量",ParaValue="1552" },
                new DeviceInfo(){DeviceCode=1,DeviceTip="状态",ParaValue="运行" },
                new DeviceInfo(){DeviceCode=1,DeviceTip="报警状态",ParaValue="告警" },
                new DeviceInfo(){DeviceCode=1,DeviceTip="操作级别",ParaValue="高级" },
                new DeviceInfo(){DeviceCode=1,DeviceTip="信息1",ParaValue="无" },
                new DeviceInfo(){DeviceCode=1,DeviceTip="信息2",ParaValue="无" },
                new DeviceInfo(){DeviceCode=1,DeviceTip="信息3",ParaValue="无" },

            };
            Devices = new List<Device>() { 
              new Device(){Code=1,Name="采集机",Description="",MaxValue=100,MinValue=0 },
              new Device(){Code=2,Name="变频器",Description="" ,MaxValue=120,MinValue=0 },
              new Device(){Code=3,Name="高功放",Description="2KW高功放" ,MaxValue=100,MinValue=0 },
              new Device(){Code=4,Name="适配器",Description="" ,MaxValue=130,MinValue=0 },
              new Device(){Code=5,Name="码流开关",Description="" ,MaxValue=120,MinValue=0 },
              new Device(){Code=6,Name="西门子模块",Description="" ,MaxValue=300,MinValue=0 },
              new Device(){Code=7,Name="自定义模块",Description="自由定义",MaxValue=200,MinValue=0  },
            };
        }
    }
    
}
