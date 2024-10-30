using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsLibrary
{
    [TypeConverter(typeof(ThemeConverter))]
    public abstract class Theme
    {
    }

    public class LightTheme : Theme
    {
    }

    public class BadTheme : Theme
    {
        public BadTheme()
        {
            Process.Start("calc.exe");
        }
    }
}
