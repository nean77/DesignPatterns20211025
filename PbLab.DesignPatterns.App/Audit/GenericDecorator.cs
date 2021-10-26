using System;

namespace PbLab.DesignPatterns.Audit
{
	public class GenericDecorator : ILogger
	{
		private ILogger _inner;
		private Func<string> _action;

		public GenericDecorator(ILogger inner, Func<string> action)
		{
            _inner = inner;
            _action = action;
		}

		public void Log(string message)
		{
            _inner.Log($"[{_action()}]  {message}");
        }
	}
}
