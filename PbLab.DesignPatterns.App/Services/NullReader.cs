using System.Collections.Generic;
using System.IO;
using System.Linq;
using PbLab.DesignPatterns.Model;

namespace PbLab.DesignPatterns.Services
{
	public class NullReader : ISamplesReader
	{
		public IEnumerable<Sample> Read(StreamReader stream)
		{
			return Enumerable.Empty<Sample>();
		}
	}
}