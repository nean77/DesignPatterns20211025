using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PbLab.DesignPatterns.Audit
{
    public class LoggerFactory
    {
        private readonly IDictionary<string, Func<ILogger, ILogger>> _decoratorsMap =
            new Dictionary<string, Func<ILogger, ILogger>>()
            {
                {"time", inner => new TimeStampDecorator(inner)},
                {"thread", inner => new GenericDecorator(inner, () => Thread.CurrentThread.ManagedThreadId.ToString())},
                {"domain", inner => new GenericDecorator(inner, () => AppDomain.CurrentDomain.Id.ToString())},
                {"machineName", inner => new GenericDecorator(inner, () => Environment.MachineName)},
            };

        public ILogger Create(string file, params string[] decorators)
        {
            ILogger result = new FileLogger(file);

            if (decorators == null || decorators.Length == 0)
            {
                return result;
            }

            var unknown = decorators.Except(_decoratorsMap.Keys).ToArray();
            if (unknown.Any())
            {
                throw new ArgumentOutOfRangeException("invalid decorator name: " + string.Join(",", unknown));
            }

            var fromEnd = decorators.Reverse();

            foreach (var decorator in fromEnd)
            {
                result = FactorizeDecorator(result, _decoratorsMap[decorator]);
            }

            return result;
        }

        private static ILogger FactorizeDecorator(ILogger inner, Func<ILogger, ILogger> factoryMethod)
        {
            inner = factoryMethod(inner);
            return inner;
        }
    }
}
