namespace PbLab.DesignPatterns.Audit
{
	internal class NullLogger : ILogger
	{
		public void Log(string message)
		{
			/* do nothing */
		}
	}
}