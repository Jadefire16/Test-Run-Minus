using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Run_Minus.Core.Test_Results
{
    public class TestResult : ITestResult
    {
        private readonly string message;
        private readonly int resultCode;

        public TestResult(string message, int code)
        {
            this.message = message;
            this.resultCode = code;
        }

        public string Message => message;
        public int ResultCode => resultCode;
    }
}
