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
        //�洢ҳ���Uri
        public readonly Dictionary<string, Uri> pageUri= new Dictionary<string, Uri>();
        public MainModel MainModel { get; set; }
        public List<LeftMenus> leftMenus { get; set; }=null;
        //Snackbar��Ϣ��ʾ
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
            new LeftMenus (){ Index=NavigationPage.MainInterfaceView.ToString(),Name="������",Kind="HomeOutline"},
            new LeftMenus (){ Index=NavigationPage.DeviceView.ToString(),Name="�豸",Kind="Memory"},
            new LeftMenus (){ Index=NavigationPage.UserView.ToString(),Name="�û�",Kind="AccountSupervisor"},
            new LeftMenus (){ Index=NavigationPage.SettingView.ToString(),Name="����",Kind="CogOutline"}
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