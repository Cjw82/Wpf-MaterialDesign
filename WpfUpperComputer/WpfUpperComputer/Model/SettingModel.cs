using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfUpperComputer.Model
{
    public class SettingModel:ObservableObject
    {
        private string colors;

        public string Colors
        {
            get { return colors; }
            set
            {
                colors = value;
                RaisePropertyChanged("Colors");
            }
        }
        private string lightcolors;

        public string LightColors
        {
            get { return lightcolors; }
            set
            {
                lightcolors = value;
                RaisePropertyChanged("LightColors");
            }
        }
        private string darkcolors;

        public string DarkColors
        {
            get { return darkcolors; }
            set
            {
                darkcolors = value;
                RaisePropertyChanged("DarkColors");
            }
        }
        //副主题色
        private string scolors;

        public string SColors
        {
            get { return scolors; }
            set
            {
                scolors = value;
                RaisePropertyChanged("SColors");
            }
        }
        
        private string selectthemeName;

        public string SelectThemeName
        {
            get { return selectthemeName; }
            set
            {
                selectthemeName = value;
                RaisePropertyChanged("SelectThemeName");
            }
        }
        private string fccolors;

        public string FcColors
        {
            get { return fccolors; }
            set
            {
                fccolors = value;
                RaisePropertyChanged("FcColors");
            }
        }
        //副主题前景色
        private string sfccolors;

        public string SFcColors
        {
            get { return sfccolors; }
            set
            {
                sfccolors = value;
                RaisePropertyChanged("SFcColors");
            }
        }
 
    }
}
