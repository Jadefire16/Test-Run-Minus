namespace Test_Run_Minus.Core.Test_Runner.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class TestClassAttribute : BaseTestAttribute
{
    public TestClassAttribute(string testName, int identifier) : base(testName, identifier) { }
}
