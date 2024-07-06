using System.Diagnostics;
using Test_Run_Minus.Common;
using Test_Run_Minus.Core.Execution.Results;

namespace Test_Run_Minus.Core.Execution.Structures
{
    internal class TestStructure : ITestRunnable
    {
        private readonly object?[]? _parameters;
        private readonly Delegate _del;

        public TestStructure(Delegate del, object?[]? parameters = null)
        {
            this._parameters = parameters;
            this._del = del;
        }
        public bool IsParameterless => _parameters is null || _parameters.Length == 0;

        public TestResult Execute()
        {
            TestResult? result;
            try
            {
                if (_parameters is null || _parameters.Length == 0)
                {
                    result = _del.DynamicInvoke() as TestResult;
                }
                else
                {
                    result = _del.DynamicInvoke(_parameters) as TestResult;
                }
            }
            catch (Exception ex)
            {
                Debug.Write($"An exception occured while running case: {ex.StackTrace}");
                return new TestResult("Execution failed due to an internal exception.", -1, ex);
            }
            return result ?? new TestResult("Execution failed.", -1, null); // Todo: replace this with an immutable TestResult object for execution failures.
        }
    }
}
