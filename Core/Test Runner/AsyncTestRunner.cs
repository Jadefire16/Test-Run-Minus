namespace Test_Run_Minus.Core.Test_Runner
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
