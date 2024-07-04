using Test_Run_Minus.Core.Execution.Results;

namespace Test_Run_Minus.Common
{
    internal interface ITestRunnable
    {
        TestResult Execute();
    }
}