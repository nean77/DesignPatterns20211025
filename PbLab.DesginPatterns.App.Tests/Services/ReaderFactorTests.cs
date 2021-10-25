using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Services
{
	[TestClass]
	public class ReaderFactorTests
	{
		private ReaderFactory _unitUnderTests;

		[TestInitialize]
		public void Initialize()
		{
			_unitUnderTests = new ReaderFactory();
		}

		[TestMethod]
		public void Create_CsvType_CsvReader()
		{
			var type = "csv";

			var reader = _unitUnderTests.Create(type);

			Assert.IsInstanceOfType(reader, typeof(CsvSamplesReader));
		}

		[TestMethod]
		public void Create_JsonType_JsonReader()
		{
			var type = "json";

			var reader = _unitUnderTests.Create(type);

			Assert.IsInstanceOfType(reader, typeof(JsonSamplesReader));
		}

		[TestMethod]
		public void Create_XmlType_XmlReader()
		{
			var type = "xml";

			var reader = _unitUnderTests.Create(type);

			Assert.IsInstanceOfType(reader, typeof(XmlSamplesReader));
		}
	}
}
