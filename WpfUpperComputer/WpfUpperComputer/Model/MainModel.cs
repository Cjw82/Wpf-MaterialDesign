using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfUpperComputer.Model
{
   public class MainModel : ObservableObject
    {
        //内容控件的切换
        private Uri mainContent;

        public Uri MainContent
        {
            get
            {
                return mainContent;
            }
            set
            {
                mainContent = value;
                RaisePropertyChanged("MainContent");
            }
        }
        //消息提示框
        private string message;

        public string MessAge
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged("MessAge");
            }
        }
        private bool isactive;

        public bool IsActive
        {
            get { return isactive; }
            set
            {
                isactive = value;
                RaisePropertyChanged("IsActive");
            }
        }
        private string date;

        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisePropertyChanged("Date");
            }
        }

    }
}
