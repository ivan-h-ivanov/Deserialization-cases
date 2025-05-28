using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeAssembly
{
    public class UnsafeClass
    {
        public UnsafeClass()
        {
            Console.WriteLine("A wild calculator appears!");
            Process.Start("calc.exe");
        }
    }
}
