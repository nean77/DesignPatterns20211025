using System.Threading;

namespace PbLab.DesignPatterns.Audit
{
	public class ThreadDecorator : ILogger
    {
        private readonly ILogger _inner;

        public ThreadDecorator(ILogger inner)
        {
            _inner = inner;
        }

        public void Log(string message)
        {
            var thread = GetThreadId();
            _inner.Log($"[{thread}]  {message}");
        }

        private string GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId.ToString();
        }
    }
}
