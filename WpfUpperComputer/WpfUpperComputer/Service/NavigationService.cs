using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using WpfUpperComputer.ViewModel;

namespace WpfUpperComputer.Service
{
    public class NavigationService: ObservableObject
    {
        private  ViewModelLocator locator;
        private  int PageCount = 0;
        public List<string> nextHistoric;
         
        public List<string> beforeHistoric;
         
        /// <summary>
        /// Stores the current pages
        /// </summary>
        private readonly Dictionary<string, Uri> pagesByKey;
        public NavigationService(string frameName)
        {
            var t = typeof(NavigationPage);
            if (!t.IsEnum)
            {
                throw new InvalidOperationException(t.ToString() + " 不是指定类型的枚举值");
            }
            pagesByKey = new Dictionary<string, Uri>();
            nextHistoric = new List<string>();
            beforeHistoric = new List<string>();
        }
        public string CurrentPageKey;
        #region 附加属性
         //public static bool GetEnable(DependencyObject obj)
        //{
        //    return (bool)obj.GetValue(EnableBeforeProperty);
        //}
        //public static void SetEnable(DependencyObject obj, bool value)
        //{
        //    obj.SetValue(EnableBeforeProperty, value);
        //}
        //// Using a DependencyProperty as the backing store for EnableBefore.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty EnableBeforeProperty =
        //    DependencyProperty.Register("EnableBefore", typeof(bool), typeof(NavigationService), new PropertyMetadata(string.Empty, OnButtonPropertyChanged));
        //private static void OnButtonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var btn = d as Button;
        //    btn.IsEnabledChanged -= OnEnableChanged;
        //    var password = (bool)e.NewValue;
        //    if (btn != null && btn.IsEnabled != password)
        //        btn.IsEnabled = password;
        //    btn.IsEnabledChanged += OnEnableChanged;
        //}

        //private static void OnEnableChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    var btn = sender as Button;
        //    SetEnable(btn, btn.IsEnabled);
        //}
        #endregion
        private bool enableNext;
        public bool EnableNext
        {
            get
            {
                return enableNext;
            }
            set
            {
                enableNext = value;
                RaisePropertyChanged("EnableNext");
            }
        }
        private bool enableBefore;

        public bool EnableBefore
        {
            get {
                return enableBefore; 
            }
            set
            {
                enableBefore = value;
                RaisePropertyChanged("EnableBefore");
            }
        }


        /// <summary>
        /// Add or alter a page providing only the enum as T. Assumes Views are in ../Views folder
        /// and follow MVVM Naming convention Name.xaml
        /// </summary>
        public void ConfigurePages()
        {
            foreach (var value in Enum.GetNames(typeof(NavigationPage)))
            {
                ConfigurePage(value, null);
            }
            PageCount = pagesByKey.Count;
        }
         

        /// <summary>
        /// Add or alter a page by providing the name of the page as a string and path.
        /// </summary>
        /// <param name="pageKey"></param>
        /// <param name="pagePath">
        /// Assumes Views are in ../View folder and follow MVVM Naming convention Name.xaml when null.
        /// </param>
        public void ConfigurePage(string pageKey, Uri pagePath = null)
        {
            if (pagePath == null)
            {
                pagePath = new Uri(String.Join("", new string[] { "../View/", pageKey, ".xaml" }), UriKind.Relative);
            }

            lock (pagesByKey)
            {
                if (pagesByKey.ContainsKey(pageKey))
                {
                    pagesByKey[pageKey] = pagePath;
                }
                else
                {
                    pagesByKey.Add(pageKey, pagePath);
                }
            }
        }
        /// <summary>
        /// Add or alter a page
        /// </summary>
        /// <param name="navigationPage"></param>
        /// <param name="pagePath"></param>
        public void Next()
        {
            if (nextHistoric.Count > 0)
            {
                if (beforeHistoric.Count > PageCount)
                {
                    beforeHistoric.RemoveAt(0);
                }
                beforeHistoric.Add(nextHistoric.Last());
                if (locator != null)
                {
                    locator.Main.MainModel.MainContent = pagesByKey[nextHistoric.Last()];
                }
                nextHistoric.RemoveAt(nextHistoric.Count - 1);
                EnableNav();
            }
        }
        public void Before()
        {
            if (beforeHistoric.Count > 1)
            {

                if (nextHistoric.Count > PageCount)
                {
                    nextHistoric.RemoveAt(0);
                }
                nextHistoric.Add(beforeHistoric.Last());
                beforeHistoric.RemoveAt(beforeHistoric.Count - 1);
                if (locator != null)
                {
                    locator.Main.MainModel.MainContent = pagesByKey[beforeHistoric.Last()];
                }
                EnableNav();
            }
        }
        /// <summary>
        /// Navigate to a page defined by enum
        /// </summary>
        /// <param name="pageKey"></param>
        public void NavigateTo(NavigationPage navigationPage)
        {
            NavigateTo(navigationPage.ToString());
        }
       
        /// <summary>
        /// Navigate to page using page name, passing a parameter
        /// </summary>
        /// <param name="pageKey"></param>
        public void NavigateTo(string pageKey)
        {
            if (pageKey != CurrentPageKey)
            {
                lock (pagesByKey)
                {
                    if (!pagesByKey.ContainsKey(pageKey))
                    {
                        throw new ArgumentException(string.Format("未找到该页面: {0} ", pageKey), nameof(pageKey));
                    }
                    //var frame = GetDescendantFromName(Application.Current.Resources["Locator"] as ViewModelLocator, frameName) as Frame;

                    locator = Application.Current.Resources["Locator"] as ViewModelLocator;
                    if (locator != null)
                    {
                        locator.Main.MainModel.MainContent = pagesByKey[pageKey];
                    }
                    //只记录总页数的步骤数量
                    if (beforeHistoric.Count > PageCount)
                    {
                        beforeHistoric.RemoveAt(0);
                    }
                    if (nextHistoric.Count>0)
                    {
                        nextHistoric.Clear();
                        EnableNext = false;
                    }
                    beforeHistoric.Add(pageKey);
                    if (beforeHistoric.Count>1)
                    {
                        EnableBefore = true;
                    }
                    CurrentPageKey = pageKey;
                }
            }
        }
        private void EnableNav()
        {
            if (nextHistoric.Count > 0)
            {
                EnableNext = true;
            }
            else
            {
                EnableNext = false;
            }
            if (beforeHistoric.Count > 1)
            {
                EnableBefore = true;
            }
            else
            {
                EnableBefore = false;
            }
        }
        /// <summary>
        /// Gets the correct Frame
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }
                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }
    }
    public enum NavigationPage
    {
        MainInterfaceView,
        DeviceView,
        UserView,
        SettingView
    }
}
