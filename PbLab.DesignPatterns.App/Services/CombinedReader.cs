using System;
using System.Collections.Generic;
using System.IO;
using PbLab.DesignPatterns.Model;

namespace PbLab.DesignPatterns.Services
{
	public class CombinedReader : ISamplesReader
	{
		private IEnumerable<ISamplesReader> _knownReaders;

		public CombinedReader(IEnumerable<ISamplesReader> knownReaders)
		{
			_knownReaders = knownReaders;
		}

		public IEnumerable<Sample> Read(StreamReader stream)
		{
			/* split by '-Type' */
			/* restore type */
			/* use know reader */

			throw new NotImplementedException();
		}
	}
}