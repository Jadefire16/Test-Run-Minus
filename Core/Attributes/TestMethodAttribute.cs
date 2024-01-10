namespace Test_Run_Minus.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : BaseTestAttribute
    {
        public TestMethodAttribute(string testName, int identifier) : base(testName, identifier) { }
    }
}
