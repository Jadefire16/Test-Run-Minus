using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Test_Run_Minus.Core.Test_Runner.Attributes;

namespace Test_Run_Minus.Core.Test_Runner
{
    internal class TestRunner : ITestRunner
    {
        private Cache<Delegate> testMethods;
        public TestRunner()
        {
            testMethods = new Cache<Delegate>();
        }

        public void Initialize()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var types = asm.GetTypes().Where(t => !t.IsAbstract && t.IsClass && t.GetCustomAttribute<TestClassAttribute>() is not null);
            IEnumerator<Type> enumerator = types.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var type = enumerator.Current;
                if (type is null)
                    continue;
                var methodCache = type.GetMethods().Where(m =>
                m.GetCustomAttribute<TestMethodAttribute>() is not null &&
                m.GetCustomAttribute<AsyncStateMachineAttribute>() is null &&
                !m.IsStatic &&
                !m.IsVirtual
                );

                object? instance = Activator.CreateInstance(type);
                if (instance is null)
                    continue;
                foreach (var method in methodCache)
                {
                    var del = Delegate.CreateDelegate(type, instance, method);
                    if (del is null)
                        continue;
                    testMethods.Add(del);
                }
                // This is all awful for so many reasons
            }
        }

        public void Run()
        {
            foreach (var method in testMethods)
            {
                try
                {
                    method.DynamicInvoke();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }
    }
}
