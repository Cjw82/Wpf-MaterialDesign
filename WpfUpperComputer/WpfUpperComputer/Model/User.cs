using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUpperComputer.Model
{
   public class User:ObservableObject
    {
         
        private string username;

        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged("UserName");
            }
        }
        private string password;

        public string PassWord
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged("PassWord");
            }
        }
        private int level;

        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                RaisePropertyChanged("Level");
            }
        }
    }
}
