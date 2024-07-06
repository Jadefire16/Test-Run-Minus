namespace Test_Run_Minus.Core.Execution.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class TestParametersAttribute : Attribute
{
    public object[] Parameters { get; }

    public TestParametersAttribute(params object[] parameters)
    {
        Parameters = parameters;
    }
}



