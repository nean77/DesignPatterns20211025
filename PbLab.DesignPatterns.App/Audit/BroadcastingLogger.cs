using PbLab.DesignPatterns.Messaging;

namespace PbLab.DesignPatterns.Audit
{
	internal class BroadcastingLogger : ILogger
	{
		private IMessenger _messenger;

		public BroadcastingLogger(IMessenger messenger)
		{
			_messenger = messenger;
		}

		public void Log(string message)
		{
			_messenger.Publish(message);
		}
	}
}