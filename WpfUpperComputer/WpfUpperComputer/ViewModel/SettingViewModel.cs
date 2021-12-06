using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WpfUpperComputer.Model;

namespace WpfUpperComputer.ViewModel
{
    public class SettingViewModel : ViewModelBase
    {
        public SettingModel Setting { get; set; }

        private RelayCommand<string> selectcommand;

        public RelayCommand<string> SelectCommand
        {
            get
            {
                if (selectcommand == null)
                {
                    selectcommand = new RelayCommand<string>((name) =>
                    {
                        Setting.SelectThemeName = name;
                    });
                }
                return selectcommand;
            }
            set
            {
                selectcommand = value;
            }
        }

        public SettingViewModel()
        {

        }
    }
}
