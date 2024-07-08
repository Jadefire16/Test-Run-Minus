using System.Reflection;

namespace Test_Run_Minus.Core.Execution.IL.Methods
{
    public class MethodRecord
    {
        public string Name { get; }
        public MethodInfo MethodInfo { get; }
        public object? Target { get; }
        public object[]? Parameters { get; }
        public bool IsStatic { get; }
        public MethodRecord(string name, MethodInfo methodInfo, object? target = null, object[]? parameters = null)
        {
            Name = name;
            MethodInfo = methodInfo;
            Target = target;
            Parameters = parameters;
            IsStatic = methodInfo.IsStatic;
        }
    }
}
