namespace Test_Run_Minus.Core.Execution
{
    internal class AsyncTestRunner : IAsyncTestRunner
    {
        public void Initialize() { }

        public Task Run()
        {
            return Task.CompletedTask;
        }
    }
}
