using System.Reflection;
using System.Runtime.Loader;

namespace Test_Run_Minus.Core.Reflection;
public class TestAssemblyLoadContext : AssemblyLoadContext
{
    public TestAssemblyLoadContext() : base(isCollectible: true) { }

    public IEnumerable<Assembly> LoadAssemblies(string path)
    {
        List<Assembly> loadedAssemblies = new();
        string[] loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

        string[] referencedPaths = Directory.GetFiles(path, "*.dll")
            .Where(file => !loadedPaths.Contains(file, StringComparer.OrdinalIgnoreCase)).ToArray();

        foreach (var assemblyPath in referencedPaths)
        {
            try
            {
                Assembly assembly = LoadFromAssemblyPath(assemblyPath);
                loadedAssemblies.Add(assembly);
            }
            catch (BadImageFormatException)
            {
                // Not a .NET assembly - ignore
                // Todo: log an event when this exception occurs to inform the user that a dll failed to load, add optional configuration to disable
            }
        }

        return null; //Todo Remove this
    }
}

/* Note:
 * Cannot unload individual assemblies, therefor AssemblyLoadContexts should be
 * mapped to the path they are loaded from and then unloaded after being used
 *
 * GC.Collect and GC.WaitForPendingFinalizers should be called if its imperative that
 * the load context be freed after usage (for memory requirements or other limitations)
 */

