using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ControlsLibrary
{
    public class CustomControl : Control
    {
        public Theme ControlTheme
        {
            get { return (Theme)GetValue(ControlThemeProperty); }
            set { SetValue(ControlThemeProperty, value); }
        }

        public static readonly DependencyProperty ControlThemeProperty =
            DependencyProperty.Register("ControlTheme", typeof(Theme), typeof(CustomControl), new PropertyMetadata(null));
    }
}
