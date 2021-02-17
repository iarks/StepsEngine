using StepEngine;
using System;
using System.Threading.Tasks;

namespace StepsEngine.Steps
{
    internal class SomeStep : Step
    {
        protected override async Task ExecuteAsync(ExecutionContext executionContext)
        {
            Console.WriteLine("1. printing-from-logger-1");
            executionContext.TryReturn("return-from-logger-1", 1, typeof(int));
            Console.WriteLine("Sleeping 1...");
            await Task.Delay(1000);
        }
    }
}