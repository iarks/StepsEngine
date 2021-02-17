using StepEngine;
using System;
using System.Threading.Tasks;

namespace StepsEngine.Steps
{
    internal class StillSomeOtherStep : Step
    {
        protected override async Task ExecuteAsync(ExecutionContext executionContext)
        {
            Console.WriteLine("4. printing-from-Logger-3");
            executionContext.TryObtainReturnValue<int>("return-from-logger-1", out int valueFrom1);
            Console.WriteLine($"5. Logger-1-return-val-in-logger-3:{valueFrom1}");
            executionContext.TryObtainReturnValue<int>("return-from-logger-2", out valueFrom1);
            Console.WriteLine($"6. Logger-2-return-val-in-logger-3:{valueFrom1}");

            Console.WriteLine("Sleeping 3 ...");
            await Task.Delay(1000);
        }
    }
}