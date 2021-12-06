using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CommonServiceLocator;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using WpfUpperComputer.ViewModel;

namespace WpfUpperComputer.View
{
    /// <summary>
    /// SettingView.xaml 的交互逻辑
    /// </summary>
    public partial class SettingView : Page
    {
        private PaletteHelper  paletteHelper = null;
        private SettingViewModel SettingViewModel = null;
        //Retrieve the app's existing theme
        private ITheme theme = null;
        private  static ViewModelLocator viewModelLocator = null;
        public SettingView()
        {
            InitializeComponent();
            viewModelLocator = Application.Current.Resources["Locator"] as ViewModelLocator;
            SettingViewModel = viewModelLocator.Setting;
            this.DataContext = SettingViewModel;
            //SettingViewModel = this.DataContext as SettingViewModel;
            SettingViewModel.Setting = new Model.SettingModel();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        { 
            paletteHelper = new PaletteHelper();
            theme = paletteHelper.GetTheme();
            //Change the base theme to Dark
            //theme.SetBaseTheme(Theme.Dark);
            //or theme.SetBaseTheme(Theme.Light);

            ////修改主要颜色
            //theme.SetPrimaryColor(Colors.YellowGreen);

            ////修改次要颜色
            //theme.SetSecondaryColor(Colors.IndianRed);


            ////更改次要主题的单一颜色，并可以选择设置相应的前景色
            //theme.SecondaryMid = new ColorPair(Colors.Black, Colors.Green);
            ///theme.PrimaryMid;
        }

        private void ColorPick_MouseDownUp(object sender, MouseButtonEventArgs e)
        {
            var forebackgroud = new ColorPair();
            var forebackgroud2= new ColorPair();
            Color color = this.colorPick.Color;
            switch (SettingViewModel.Setting.SelectThemeName)
            {
                case "Mid":
                    //修改主题色
                    theme.SetPrimaryColor(color);
                    //forebackgroud.ForegroundColor = color;
                    forebackgroud.Color = SwitchColor(color, "L");
                    SettingViewModel.Setting.LightColors = forebackgroud.Color.ToString();
                    theme.PrimaryLight = forebackgroud;
                    forebackgroud2.Color = SwitchColor(color, "D");
                    SettingViewModel.Setting.DarkColors = forebackgroud2.Color.ToString();
                    theme.PrimaryDark = forebackgroud2;
                    SettingViewModel.Setting.Colors = color.ToString();
                    break;
                case "Sid":
                    //修改辅助主题色
                    theme.SetSecondaryColor(color);
                    SettingViewModel.Setting.SColors = color.ToString();
                    break;
                case "MidText":
                    forebackgroud.Color = theme.PrimaryMid.Color;
                    forebackgroud.ForegroundColor = color;
                    theme.PrimaryMid = forebackgroud;
                    SettingViewModel.Setting.FcColors = color.ToString();
                    break;
                case "SidText":
                    //副主题前景色
                    forebackgroud.Color = theme.SecondaryMid.Color;
                    forebackgroud.ForegroundColor = color;
                    theme.SecondaryMid = forebackgroud;
                    SettingViewModel.Setting.SFcColors = color.ToString();
                    break;
                default:
                    this.settingSnack.MessageQueue?.Enqueue(
                    "请选择主题或字体进行配色",
                    null,
                    null,
                    null,
                    false,
                    true,
                    TimeSpan.FromSeconds(1.5));
                    break;
            }
            paletteHelper.SetTheme(theme);
        }
        private Color SwitchColor(Color color,string theme)
        {
            Color colo1 = new Color();
            double br = 0;
            double bg = 0;
            double bb = 0;
            if (theme=="L")
            {
                br = color.R + color.R * 0.6 > 250 ? 250 : color.R + color.R * 0.4;
                bg = color.G + color.G * 0.6 > 250 ? 250 : color.G + color.G * 0.4;
                bb = color.B + color.B * 0.6 > 250 ? 250 : color.B + color.B * 0.4;
                
            }
            else {
                br = color.R - color.R * 0.6 < 0 ? 0 : color.R - color.R * 0.4;
                bg = color.G - color.G * 0.6 < 0 ? 0 : color.G - color.G * 0.4;
                bb = color.B - color.B * 0.6 < 0 ? 0 : color.B - color.B * 0.4;
            } 
            colo1 = Color.FromArgb(color.A,Convert.ToByte(br), Convert.ToByte(bg), Convert.ToByte(bb));
            return colo1;
        }
    }
}
