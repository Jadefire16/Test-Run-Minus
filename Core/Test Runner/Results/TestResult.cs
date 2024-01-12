namespace Test_Run_Minus.Core.Test_Runner.Results;
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

