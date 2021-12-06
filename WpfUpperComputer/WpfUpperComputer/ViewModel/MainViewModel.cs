using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Navigation;
using WpfUpperComputer.Common;
using WpfUpperComputer.Model;

namespace WpfUpperComputer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //存储页面的Uri
        public readonly Dictionary<string, Uri> pageUri= new Dictionary<string, Uri>();
        public MainModel MainModel { get; set; }
        public List<LeftMenus> leftMenus { get; set; }=null;
        //Snackbar消息提示
        private RelayCommand<string> snackbarCommand;
        public RelayCommand<string> SnackbarCommand
        {
            get
            {
                if (snackbarCommand == null)
                {
                    snackbarCommand = new RelayCommand<string>((p)=> {
                        MainModel.IsActive = false;
                        MainModel.MessAge = string.Empty;
                    });
                }
                return snackbarCommand;
            }
            set { snackbarCommand = value; }
        }
        public MainViewModel()
        {
            ConfigurePages();
            MainModel = new MainModel();
            leftMenus = new List<LeftMenus>() {
            new LeftMenus (){ Index=NavigationPage.MainInterfaceView.ToString(),Name="主界面",Kind="HomeOutline"},
            new LeftMenus (){ Index=NavigationPage.DeviceView.ToString(),Name="设备",Kind="Memory"},
            new LeftMenus (){ Index=NavigationPage.UserView.ToString(),Name="用户",Kind="AccountSupervisor"},
            new LeftMenus (){ Index=NavigationPage.SettingView.ToString(),Name="设置",Kind="CogOutline"}
            };
        }
        public void ConfigurePages()
        {
            foreach (var value in Enum.GetNames(typeof(NavigationPage)))
            {
                ConfigurePage(value);
            }
        }
        public void ConfigurePage(string pageKey)
        {
            
            var pagePath = new Uri(String.Join("", new string[] { "../View/", pageKey, ".xaml" }), UriKind.Relative);
            lock (pageUri)
            {
                if (pageUri.ContainsKey(pageKey))
                {
                    pageUri[pageKey] = pagePath;
                }
                else
                {
                    pageUri.Add(pageKey, pagePath);
                }
            }
        }
        public class LeftMenus
        {
            public string Index { get; set; }
            public string Name { get; set; }
            public string Kind { get; set; }
        }
    }
}