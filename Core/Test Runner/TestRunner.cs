using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test_Run_Minus.Core.Test_Runner
{
    internal class TestRunner : ITestRunner
    {
        private readonly HashSet<Type> types;
        private readonly TestTypeCache cache;

        public TestRunner(HashSet<string> types)
        {
            this.types = new HashSet<Type>();
            cache = new TestTypeCache();
        }

        public void Initialize()
        {

        }

        public void Run()
        {
            //foreach (var method in methods)
            //{
            //    string typeName = method.Key;
            //    Type? type = Type.GetType(typeName);
            //    if (type is null)
            //        continue; //TODO: Throw Error

            //}
        }
    }
}
