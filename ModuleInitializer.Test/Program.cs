using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace ModuleInitializer.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LoadUnsafe();
            //LoadInMetadata();
            //LoadInContext();
        }

        private static void LoadInContext()
        {
            PrepareContext();
            DisposeContext();
            LoadType();
        }

        private static void DisposeContext()
        {
            loadContext.Unload();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static void LoadInMetadata()
        {
            string runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
            string[] runtimeAssemblies = Directory.GetFiles(runtimeDirectory, "*.dll");

            var loadContext = new MetadataLoadContext(new PathAssemblyResolver(runtimeAssemblies));
            var assembly = loadContext.LoadFromAssemblyPath("ModuleInitializer.dll");
            var type = assembly.GetType("ModuleInitializer.SafeClass");
            Activator.CreateInstance(type);
        }

        private static AssemblyLoadContext loadContext;

        private static void PrepareContext()
        {
            string runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
            string[] runtimeAssemblies = Directory.GetFiles(runtimeDirectory, "*.dll");

            loadContext = new AssemblyLoadContext(null, true);
            loadContext.LoadFromAssemblyPath(Path.GetFullPath("ModuleInitializer.dll"));
        }

        private static void LoadType()
        {
            var assembly = loadContext.Assemblies.FirstOrDefault();
            if (assembly != null)
            {
                var type = assembly.GetType("ModuleInitializer.SafeClass");
                Activator.CreateInstance(type);
            }
        }

        private static void LoadUnsafe()
        {
            var assembly = Assembly.LoadFrom("ModuleInitializer.dll");
            var type = assembly.GetType("ModuleInitializer.SafeClass");
            Activator.CreateInstance(type);
        }
    }
}
