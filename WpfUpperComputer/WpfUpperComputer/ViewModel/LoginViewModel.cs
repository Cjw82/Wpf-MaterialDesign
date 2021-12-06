using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfUpperComputer.Model;
using WpfUpperComputer.Service;
using WpfUpperComputer.View;

namespace WpfUpperComputer.ViewModel
{
   public class LoginViewModel:ViewModelBase
    {
        private string loginMess;
        public string LoginMess
        {
            get { return loginMess; }
            set
            {
                loginMess = value;
                RaisePropertyChanged("LoginMess");
            }
        }
        public User User { get; set; }
        public LoginViewModel( ) 
        {
            User =new User { UserName="张三",PassWord="123456"  };
        }
        private RelayCommand<Window> loginCommand;

        public RelayCommand<Window> LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand<Window>(login=> {
                        if (User.UserName =="张三" && User.PassWord == "123456")
                        {
                            LoginMess = "登录成功!!";
                            //TextBlock text = login.FindName("loginTip") as TextBlock;
                            //if (text !=null)
                            //{
                            //    text.SetValue(TextBlock.ForegroundProperty, Brushes.Green);
                            //}
                            new MainWindow().Show();
                            login.Close();
                        }
                        else {
                            LoginMess = "用户名或密码错误,登录失败!!";
                        }
                    });
                }
                return loginCommand;
            }
            set { loginCommand = value; }
        }
    }
}
