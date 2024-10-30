using System;
using System.ComponentModel;

namespace ControlsLibrary   
{
    internal class ThemeConverter : System.ComponentModel.TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var stringValue = value as string;
            var type = Type.GetType(stringValue);
            if (typeof(Theme).IsAssignableFrom(type))
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}