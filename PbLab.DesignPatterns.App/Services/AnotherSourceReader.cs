using PbLab.DesignPatterns.Communication;
using PbLab.DesignPatterns.Execution;
using PbLab.DesignPatterns.Model;
using PbLab.DesignPatterns.Tools;
using System.Linq;

namespace PbLab.DesignPatterns.Services
{
	public sealed class OnlyFilesSourceReader : SourceReader
	{
		public OnlyFilesSourceReader(
			ObjectsPool<ISamplesReader> readers, 
			IChanelFactory chanelFactory, 
			IScheduler<string, Sample> defaultScheduler = null) 
			: base(readers, chanelFactory, defaultScheduler)
		{
		}

		protected override string ExtractChannel(string location)
		{
			return "file";
		}
	}
}
