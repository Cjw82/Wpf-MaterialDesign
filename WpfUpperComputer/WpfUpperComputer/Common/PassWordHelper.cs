using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfUpperComputer.Common
{
    public class PassWordHelper : DependencyObject
    {

        //附加属性不需要属性包装器,进行封装,因为附加属性可以被用到任何的依赖对象中


        //创建附加依赖属性

        //创建两个静态方法,用来设置和获取属性值
        public static string GetPassWord(DependencyObject obj)
        {
            return (string)obj.GetValue(PassWordProperty);
        }

        public static void SetPassWord(DependencyObject obj, string value)
        {
            obj.SetValue(PassWordProperty, value);
        }

        //PropertyMetadata: 属性元数据(参数1:属性默认值 参数2:回调函数)

        //使用RegisterAttached进行注册,而不是使用普通的附加属性Register注册
        public static readonly DependencyProperty PassWordProperty =
            DependencyProperty.RegisterAttached("PassWord", typeof(string), typeof(PassWordHelper), new PropertyMetadata(string.Empty, OnPassWordPropertyChanged));
       
        //回调函数,用于通知更改属性值的变化
        private static void OnPassWordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var box = d as PasswordBox;
            box.PasswordChanged -= OnPasswordChanged;
            var password = (string)e.NewValue;
            if (box != null && box.Password != password)
                box.Password = password;
            box.PasswordChanged += OnPasswordChanged;
        }
        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var box = sender as PasswordBox;
            SetPassWord(box, box.Password);
        }
    }
}
