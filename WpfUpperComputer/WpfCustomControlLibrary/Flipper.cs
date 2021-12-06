using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomControlLibrary
{
    public class Flipper : Control
    {
        public bool IsFlipped
        {
            get { return (bool)GetValue(IsFlippedProperty); }
            set { base.SetValue(IsFlippedProperty, value); }
        }

        public static readonly DependencyProperty IsFlippedProperty =
            DependencyProperty.Register("IsFlipped", typeof(bool), typeof(Flipper), new PropertyMetadata(default(bool)));


        public object FrontContent
        {
            get { return base.GetValue(FrontContentProperty); }
            set { base.SetValue(FrontContentProperty, value); }
        }

        public static readonly DependencyProperty FrontContentProperty =
            DependencyProperty.Register("FrontContent", typeof(object), typeof(Flipper), new PropertyMetadata(default(object)));


        public object BackContent
        {
            get { return base.GetValue(BackContentProperty); }
            set { base.SetValue(BackContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackContentProperty =
            DependencyProperty.Register("BackContent", typeof(object), typeof(Flipper), new PropertyMetadata(default(object)));

        public DataTemplateSelector FrontContentTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(FrontContentTemplateSelectorProperty);
            set => SetValue(FrontContentTemplateSelectorProperty, value);
        }
        public static readonly DependencyProperty FrontContentTemplateSelectorProperty = DependencyProperty.Register(
                  nameof(FrontContentTemplateSelector), typeof(DataTemplateSelector), typeof(Flipper), new PropertyMetadata(default(DataTemplateSelector)));

        public DataTemplateSelector BackContentTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(BackContentTemplateSelectorProperty);
            set => SetValue(BackContentTemplateSelectorProperty, value);
        }
        public static readonly DependencyProperty BackContentTemplateSelectorProperty = DependencyProperty.Register(
                  nameof(BackContentTemplateSelector), typeof(DataTemplateSelector), typeof(Flipper), new PropertyMetadata(default(DataTemplateSelector)));
        //用于绘制边框
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Con.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Flipper), new PropertyMetadata(null));
        static Flipper()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Flipper), new FrameworkPropertyMetadata(typeof(Flipper)));
        }
    }
}
