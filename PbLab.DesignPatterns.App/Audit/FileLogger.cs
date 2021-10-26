using System;
using System.IO;

namespace PbLab.DesignPatterns.Audit
{
	internal class FileLogger : ILogger
	{
		private string _file;

		public FileLogger(string file)
		{
			_file = file;
		}

		public void Log(string message)
		{
			message = message + Environment.NewLine;
			File.AppendAllText(_file, message);
		}
	}
}