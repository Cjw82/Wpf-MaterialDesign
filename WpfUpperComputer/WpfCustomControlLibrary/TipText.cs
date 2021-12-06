using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControlLibrary
{
    public class TipText:Control
    {

        public string TipTextValue
        {
            get { return (string)GetValue(TipTextValueProperty); }
            set { SetValue(TipTextValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TipTextValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipTextValueProperty =
            DependencyProperty.Register("TipTextValue", typeof(string), typeof(TipText), new PropertyMetadata("数据值"));



        public string Tip
        {
            get { return (string)GetValue(TipProperty); }
            set { SetValue(TipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TipText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipProperty =
            DependencyProperty.Register("Tip", typeof(string), typeof(TipText), new PropertyMetadata("提示"));


        static TipText()
        {
            //重写依赖属性实例的元数据
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TipText), new FrameworkPropertyMetadata(typeof(TipText)));
        }
    }
}
