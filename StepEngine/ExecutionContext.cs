using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static StepEngine.Step;

namespace StepEngine
{
    public sealed class ExecutionContext
    {
        private readonly IDictionary<string, Tuple<Object, Type>> _returns;
        private readonly ICollection<StepExecutor> _stepsToExecute;
        private readonly ICollection<Type> _stepsToSkip;

        public ExecutionContext(params (string, object)[] contextInitialiser)
        {
            _returns = new Dictionary<string, Tuple<object, Type>>();

            _stepsToExecute = new List<StepExecutor>();
            _stepsToSkip = new HashSet<Type>();

            InitContext(contextInitialiser);
        }

        private void InitContext((string, object)[] contextInitialiser)
        {
            foreach (var ctxInit in contextInitialiser)
            {
                _returns.Add(ctxInit.Item1, Tuple.Create(ctxInit.Item2, ctxInit.GetType()));
            }
        }

        public ExecutionContext Then(Step step)
        {
            _stepsToExecute.Add(step.AsyncExecuter);
            return this;
        }

        public async Task ExecuteAllAsync()
        {
            foreach (var stepExecutor in _stepsToExecute)
            {
                if (!_stepsToSkip.Contains(stepExecutor.Target.GetType()))
                {
                    await stepExecutor.Invoke(this);
                }
            }
        }

        public void TryReturn(string name, object value, Type type)
        {
            if (!_returns.ContainsKey(name))
            {
                _returns.Add(name, Tuple.Create(value, type));
                return;
            }
            _returns[name] = Tuple.Create(value, type);
        }

        public bool TryRemoveReturn(string name) => _returns.Remove(name);

        public bool TryObtainReturnValue<T>(string key, out T value)
        {
            if (_returns.TryGetValue(key, out Tuple<object, Type> val) && typeof(T).Equals(val.Item2))
            {
                value = (T)val.Item1;
                return true;
            }
            value = default;
            return false;
        }

        public void TrySkipStep<T>() where T : Step => _stepsToSkip.Add(typeof(T));

        public void TryRemoveSkippedStep<T>() => _stepsToSkip.Remove(typeof(T));
    }
}