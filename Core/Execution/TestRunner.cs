using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Test_Run_Minus.Core.Execution.Attributes;
using Test_Run_Minus.Core.Execution.Results;
using Test_Run_Minus.Core.Execution.Structures;

namespace Test_Run_Minus.Core.Execution
{
    public class TestRunner
    {
        private Dictionary<string, TestCase> _cases = new();
        public void Initialize(Assembly asm)
        {
            IEnumerable<Type> types = asm.GetTypes().Where(t => t is { IsAbstract: false, IsClass: true } && t.GetCustomAttribute<TestClassAttribute>() is not null);
            using IEnumerator<Type> enumerator = types.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Type type = enumerator.Current;
                IEnumerable<MethodInfo> methods = type.GetMethods().Where(m =>
                    m.GetCustomAttribute<TestMethodAttribute>() is not null &&
                    m.GetCustomAttribute<AsyncStateMachineAttribute>() is null &&
                    m is { IsStatic: false, IsVirtual: false }
                );

                object? instance = Activator.CreateInstance(type);
                if (instance is null)
                    continue;
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine(method.Name);
                    Delegate del = Delegate.CreateDelegate(typeof(Delegate), instance, method);
                }
            }
            // Todo cast enumerators to some cached list or array and populate test cases
        }

        public void Execute()
        {
            
        }

        class TestCase
        {
            private object _classInstance;
            private MethodInfo _method;
            private object[] _parameters;

            public TestCase(MethodInfo method, object[] parameters = null, object classInstance = null)
            {
                _method = method ?? throw new ArgumentNullException(nameof(method));
                this._parameters = parameters;
            }

            public TestResult Invoke()
            {
                try
                {
                    _method.Invoke(_classInstance, _parameters);
                }
                catch (Exception ex)
                {
                    return new TestResult(ex);
                }
                return new TestResult("Test Succeeded", 0, null);
                // Todo: Add logic to handle timeouts on tests, may need to implement something similar to Unity's Coroutine system
            }
        }

    }
}

/*Todo: Add interfaces to handle execution and initialization
Should this initialize in a constructor? Is lazy initialization needed?
*/

/* Steps:
 * Gather all assemblies which have a class with the [TestClass] attribute in them
 * Iterate through each test class and reflect out all methods which contain the [TestMethod] attribute
 * Add all test methods to a list in a map with the key as the parent [TestClass] name (Default to some default entry if a test class wasn't present and throw an error)
 * Throw warnings for all test classes which don't contain a [TestMethod] attribute
 * Create a map and map the number of parameters required for each method (might need to wrap in a class of some sort?)
 * Sanity check over each method and determine they have a [TestParameters] attribute, map the parameters to the method
 * Iterate over each list entry in the map, calling execute and add their test results to an array
 * Produce a log of all test passes, failures, skips and flakes
 * Dump results to ILogger
 */