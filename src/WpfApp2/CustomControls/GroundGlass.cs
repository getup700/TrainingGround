using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp2.CustomControls
{
    class GroundGlass : Control
    {
        static GroundGlass()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GroundGlass), new FrameworkPropertyMetadata(typeof(GroundGlass)));
        }



        public ImageSource BackgroundImage
        {
            get { return (ImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(ImageSource), typeof(GroundGlass), new PropertyMetadata(null));


    }
}
