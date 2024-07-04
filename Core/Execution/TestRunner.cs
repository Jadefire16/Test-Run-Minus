using System.Reflection;
using System.Runtime.CompilerServices;
using Test_Run_Minus.Core.Execution.Attributes;
using Test_Run_Minus.Core.Execution.Structures;

namespace Test_Run_Minus.Core.Execution
{
    public class TestRunner
    {
        private readonly Cache<TestStructure> _cases = new();

        public void Initialize()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = asm.GetTypes().Where(t => t is { IsAbstract: false, IsClass: true } && t.GetCustomAttribute<TestClassAttribute>() is not null);
            using IEnumerator<Type> enumerator = types.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Type type = enumerator.Current;
                IEnumerable<MethodInfo> methodCache = type.GetMethods().Where(m =>
                    m.GetCustomAttribute<TestMethodAttribute>() is not null &&
                    m.GetCustomAttribute<AsyncStateMachineAttribute>() is null &&
                    m is { IsStatic: false, IsVirtual: false }
                );

                object? instance = Activator.CreateInstance(type);
                if (instance is null)
                    continue;
                foreach (MethodInfo method in methodCache)
                {
                    Console.WriteLine(method.Name);
                    Delegate del = Delegate.CreateDelegate(typeof(Delegate), instance, method);
                    _cases.Add(new TestStructure(del));
                }
            }
        }

        public void Execute()
        {
            foreach (TestStructure caseStructure in _cases)
            {
                caseStructure.Run();
            }
        }
    }
}

/*Todo: Add interfaces to handle execution and initialization
Should this initialize in a constructor? Is lazy initialization needed?
*/