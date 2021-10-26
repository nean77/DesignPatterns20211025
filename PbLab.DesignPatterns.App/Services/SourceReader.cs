using PbLab.DesignPatterns.Audit;
using PbLab.DesignPatterns.Model;
using PbLab.DesignPatterns.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PbLab.DesignPatterns.Services
{
    public class SourceReader
    {
        private static ObjectsPool<ISamplesReader> Readers;

        static SourceReader()
		{
            Readers = new ObjectsPool<ISamplesReader>(new ReaderFactory());
		}

        public static IEnumerable<Sample> ReadAllSources(IEnumerable<string> paths)
        {
            var result = new List<Sample>();
			var reportTemplate = new ReportPrototype(DateTime.Now);

			var reports = new List<string>();

			foreach (var file in paths)
			{
				var stats = new StatsBuilder(file);

				var stopper = new Stopwatch();
				stopper.Start();

				IEnumerable<Sample> samples = ReadAllSamples(file);

				stopper.Stop();

				result.AddRange(samples);

				stats.AddDuration(stopper.Elapsed);
				stats.AddCount((uint)samples.Count());

				reports.Add(reportTemplate.Clone(stats.Build()));
			}


			Store(reports);
			return result;
        }

		private static void Store(List<string> reports)
		{
			var file = $"samplesRead.{DateTime.Now.AsFileName()}.txt";

			var logger = new LoggerFactory().Create(file);

			reports.ForEach(report => logger.Log(report));
		}

		public static IEnumerable<Sample> ReadAllSamples(string file)
		{
			var reader = Readers.Borrow(new FileInfo(file).Extension);

			IEnumerable<Sample> samples;
			using (StreamReader stream = FileProxy.OpenText(file))
			{
				samples = reader.Read(stream);
			}

			Readers.Release(reader);
			return samples;
		}
	}
}
