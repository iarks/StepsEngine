using System.Threading.Tasks;

namespace StepEngine
{
    public abstract class Step
    {
        protected internal delegate Task StepExecutor(ExecutionContext executionContext);

        protected internal StepExecutor AsyncExecuter;

        protected Step()
        {
            AsyncExecuter = ExecuteAsync;
        }

        protected abstract Task ExecuteAsync(ExecutionContext executionContext);
    }
}