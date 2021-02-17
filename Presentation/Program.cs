using StepsEngine.StepExecutionFramework;
using StepsEngine.Steps;
using System;
using System.Threading.Tasks;

namespace StepsEngine
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await new ExecutionContext()
               .Then(new SomeStep())
               .Then(new SomeOtherStep())
               .Then(new StillSomeOtherStep())
               .ExecuteAllAsync();
            Console.WriteLine("sup");
            Console.ReadKey();
        }
    }
}