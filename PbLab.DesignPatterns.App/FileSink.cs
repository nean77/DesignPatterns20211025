using PbLab.DesignPatterns.Messaging;
using System;
using System.IO;

namespace PbLab.DesignPatterns
{
	internal class FileSink : ISubscriber
	{
		private string _file;

		public FileSink(string file)
		{
			_file = file;
		}

		public void Notify(string message)
		{
			message = message + Environment.NewLine;
			File.AppendAllText(_file, message);
		}
	}
}