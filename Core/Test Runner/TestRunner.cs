using System;
using System.Collections.Generic;
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
            
        }
    }
}
