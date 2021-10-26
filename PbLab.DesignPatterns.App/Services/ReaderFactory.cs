using PbLab.DesignPatterns.Tools;
using System;
using System.IO;

namespace PbLab.DesignPatterns.Services
{
	public class ReaderFactory : IFactory<ISamplesReader>
	{
		public ISamplesReader Create(string type)
		{
			type = type.Trim('.');
			return FactorizeFrom(type);
		}

		public ISamplesReader Create(FileInfo file)
		{
			var type = file.Extension.Trim('.');
			return FactorizeFrom(type);
		}

		private static ISamplesReader FactorizeFrom(string type)
		{
			switch (type)
			{
				case "csv": return new CsvSamplesReader();
				case "json": return new JsonSamplesReader();
				case "xml": return new XmlSamplesReader();
				default: throw new NotImplementedException(); // Exception driven development or maybe sth else?
			}
		}
	}
}
