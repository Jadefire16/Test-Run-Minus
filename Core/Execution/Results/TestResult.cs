namespace Test_Run_Minus.Core.Execution.Results;
public class TestResult : ITestResult
{
    public TestResult(string message, int code, Exception? ex = null)
    {
        this.Message = message;
        this.ResultCode = code;
        this.Exception = ex;
        this.TestId = Guid.NewGuid();
    }

    public int ResultCode { get; }
    public string Message { get; }
    public Exception? Exception { get; }
    public Guid TestId { get; }
}

//TODO: Should TestResult also contain a reference to the test logs? Should they be mapped to each set of logs?