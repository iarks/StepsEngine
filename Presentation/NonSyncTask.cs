using StepEngine;
using System;
using System.Threading.Tasks;

namespace StepsEngine
{
    internal class NonSyncTask : Step
    {
        protected override Task ExecuteAsync(ExecutionContext executionContext)
        {
            return Task.Run(() => Console.WriteLine("in non sync task"));
        }
    }
}