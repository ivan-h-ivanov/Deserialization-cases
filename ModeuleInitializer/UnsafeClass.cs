using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModuleInitializer
{
    internal class UnsafeClass
    {
        [ModuleInitializer]
        public static void UnsafeMethod()
        {
            Process.Start("calc.exe");
        }
    }
}
