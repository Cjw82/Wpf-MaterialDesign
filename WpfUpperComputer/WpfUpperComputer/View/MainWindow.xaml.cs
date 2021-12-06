using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfUpperComputer.Common;
using WpfUpperComputer.Model;
using WpfUpperComputer.ViewModel;

namespace WpfUpperComputer.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private static MainViewModel MainViewModel = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             //viewModelLocator = Application.Current.Resources["Locator"] as ViewModelLocator;
            //MainViewModel = viewModelLocator.Main;
            MainViewModel = this.DataContext as MainViewModel ;
            GetCurrentDate();
            //MainViewModel.navigationService.NavigateTo(NavigationPage.MainInterfaceView);
            MainFrameContent.NavigationService.Navigate(MainViewModel.pageUri[NavigationPage.MainInterfaceView.ToString()]);
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (ToggleUserEdit.IsChecked == true)
            {
                //MainViewModel.navigationService.NavigateTo(NavigationPage.UserView);
                MainFrameContent.NavigationService.Navigate(MainViewModel.pageUri[NavigationPage.UserView.ToString()]);
            }
        }
        private void themeMode_Click(object sender, RoutedEventArgs e)
        {
            bool check = themeMode.IsChecked == true ? true : false;
            var paletteHelper = new PaletteHelper();
            //Retrieve the app's existing theme
            ITheme theme = paletteHelper.GetTheme();
            if (check)
            {
                theme.SetBaseTheme(Theme.Dark);
            }
            else
            {
                theme.SetBaseTheme(Theme.Light);
            }
            paletteHelper.SetTheme(theme);
        }
        //获取时间
        private void GetCurrentDate()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler((sender,e) => {
                MainViewModel.MainModel.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            });
            //_timer.Interval = new TimeSpan(10000000);
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.IsEnabled = true;
            _timer.Start();
        }
        private void LeftMenuListBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = this.LeftMenuListBox.SelectedItem as MainViewModel.LeftMenus;
            this.TOpenLeftMenu.IsChecked = false;
            //MainViewModel.navigationService.NavigateTo(item.Index);
            MainFrameContent.NavigationService.Navigate(MainViewModel.pageUri[item.Index]);
        }
        private void BeforePage_Click(object sender, RoutedEventArgs e)
        {
            //MainViewModel.navigationService.Before();
            MainFrameContent.NavigationService.GoBack();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            //MainViewModel.navigationService.Next();
            MainFrameContent.NavigationService.GoForward();
        }
        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            //MainViewModel.navigationService.NavigateTo(NavigationPage.MainInterfaceView);
            MainFrameContent.NavigationService.Navigate(MainViewModel.pageUri[NavigationPage.MainInterfaceView.ToString()]);
        }
    }
}
