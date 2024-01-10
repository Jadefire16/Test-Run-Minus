namespace Test_Run_Minus.Core.Test_Results
{
    public interface ITestResult
    {
        string Message { get; }
        int ResultCode { get; }
    }
}