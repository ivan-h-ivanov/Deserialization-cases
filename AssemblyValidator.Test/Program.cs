using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyValidator.Test
{
    internal class Program
    {
        const string SafeAssembly = "SafeAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        // Safe input 'SafeAssembly.SafeClass'
        // Unsafe input "UnsafeAssembly.UnsafeClass, UnsafeAssembly, Version = 1.0.0.0, Culture = neutral, Foo='"

        static void Main(string[] args)
        {
            string typeName;
            while ((typeName = Console.ReadLine()) != string.Empty)
            {
                var secureTypeName = string.Format("{0}, {1}", typeName, SafeAssembly);
                Console.WriteLine("You are loading" + secureTypeName);
                var type = Type.GetType(secureTypeName);
                Activator.CreateInstance(type);
            }
        }
    }
}
