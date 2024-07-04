namespace Test_Run_Minus.Core.Execution.Results;

public interface ITestResult
{
    string Message { get; }
    int ResultCode { get; }
}