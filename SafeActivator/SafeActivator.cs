using System;

namespace SafeActivator
{
    public static class SafeActivator
    {
        static object CreateInstance(string typeName)
        {
            if (Validate(typeName))
            {
                return System.Activator.CreateInstance(System.Type.GetType(typeName));
            }
            else
            {
                throw new InvalidOperationException($"Initialization of {typeName} is not allowed");
            }
        }

        static bool Validate(string typeName)
        {
            return true;
        }
    }
}
