using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Run_Minus.Core.Test_Runner
{
    internal class AsyncTestRunner : IAsyncTestRunner
    {
        public void Initialize() { }

        public Task Run()
        {
            return Task.CompletedTask;
        }
    }
}
