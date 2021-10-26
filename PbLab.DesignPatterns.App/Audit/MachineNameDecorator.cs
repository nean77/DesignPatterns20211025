using System;

namespace PbLab.DesignPatterns.Audit
{
	public class MachineNameDecorator : ILogger
    {
        private readonly ILogger _inner;

        public MachineNameDecorator(ILogger inner)
        {
            _inner = inner;
        }

        public void Log(string message)
        {
            var name = GetMachineName();
            _inner.Log($"[{name}]  {message}");
        }

        private string GetMachineName()
        {
            return Environment.MachineName;
        }
    }
}
