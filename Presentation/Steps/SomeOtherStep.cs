using StepEngine;
using System;
using System.Threading.Tasks;

namespace StepsEngine.Steps
{
    internal class SomeOtherStep : Step
    {
        protected override async Task ExecuteAsync(ExecutionContext executionContext)
        {
            Console.WriteLine("2. printing-from-logger-2");
            executionContext.TryObtainReturnValue<int>("return-from-logger-1", out int valueFrom1);
            Console.WriteLine($"3. Logger-1-return-val-in-logger-2:{valueFrom1}");
            executionContext.TryReturn("return-from-logger-2", 1, typeof(int));
            Console.WriteLine("Sleeping 2 ...");
            await Task.Delay(1000);

            executionContext.TrySkipStep<StillSomeOtherStep>();
        }
    }
}