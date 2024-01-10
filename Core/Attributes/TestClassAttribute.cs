namespace Test_Run_Minus.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClassAttribute : BaseTestAttribute
    {
        public TestClassAttribute(string testName, int identifier) : base(testName, identifier) { }
    }
}
