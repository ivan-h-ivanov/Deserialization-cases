namespace ModuleInitializer.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(SafeClass);
            Activator.CreateInstance(type);
        }
    }
}
