using PbLab.DesignPatterns.Tools;
using System;

namespace PbLab.DesignPatterns.Services
{
	public class ReaderFactory : IFactory<ISamplesReader>
	{
		public ISamplesReader Create(string schema)
		{
			return FactorizeFrom(schema);
		}

		private static ISamplesReader FactorizeFrom(string schema)
		{
			switch (schema)
			{
				case "csv": return new CsvSamplesReader();
				case "json": return new JsonSamplesReader();
				case "xml": return new XmlSamplesReader();
				case "mix": return new CombinedReader(new ISamplesReader[] { new CsvSamplesReader() , new JsonSamplesReader(), new XmlSamplesReader() });
				default: throw new NotImplementedException(); // Exception driven development or maybe sth else?
			}
		}
	}
}
