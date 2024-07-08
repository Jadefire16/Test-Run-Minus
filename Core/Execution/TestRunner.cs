using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Test_Run_Minus.Core.Execution.Attributes;
using Test_Run_Minus.Core.Execution.IL.Methods;
using Test_Run_Minus.Core.Execution.Results;
using Test_Run_Minus.Core.Execution.Structures;

namespace Test_Run_Minus.Core.Execution
{
    public class TestRunner
    {
        private HashSet<MethodRecord> _cases = new();
        public void Initialize(Assembly asm)
        {
            IEnumerable<Type> types = asm.GetTypes().Where(t => t is { IsAbstract: false, IsClass: true } && t.GetCustomAttribute<TestClassAttribute>() is not null);
            using IEnumerator<Type> enumerator = types.GetEnumerator();
            foreach (var type in types)
            {
                IEnumerable<MethodInfo> methods = type.GetMethods().Where(m =>
                    m.GetCustomAttribute<TestMethodAttribute>() is not null &&
                    m.GetCustomAttribute<AsyncStateMachineAttribute>() is null &&
                    m is { IsStatic: false, IsVirtual: false }
                );
                object? instance = Activator.CreateInstance(type);
                Debug.Assert(instance is not null, "Type instance must not be null");

                foreach (MethodInfo method in methods)
                {
                    TestParametersAttribute? parameterAttribute = method.GetCustomAttribute<TestParametersAttribute>();
                    object[]? parameters = parameterAttribute?.Parameters;
                   _cases.Add(new MethodRecord(type.Name + method.Name, method, instance, parameters));
                }
            }
        }

        public void Execute()
        {
            foreach (MethodRecord testCase in _cases)
            {
                var result = testCase.MethodInfo.Invoke(testCase.Target, testCase.Parameters);
                Console.WriteLine(result);
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