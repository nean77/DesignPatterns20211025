using PbLab.DesignPatterns.Audit;
using PbLab.DesignPatterns.Communication;
using PbLab.DesignPatterns.Execution;
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
		private static IChanelFactory ChanelFactory;

        static SourceReader()
		{
            Readers = new ObjectsPool<ISamplesReader>(new ReaderFactory());
			ChanelFactory = new ChanelFactory();
		}

        public static IEnumerable<Sample> ReadAllSources(IEnumerable<string> paths, IScheduler<string, Sample> scheduler)
        {
			return scheduler.Schedule(paths, location => ProcessSource(location));
        }

		private static IEnumerable<Sample> ProcessSource(string location)
		{
			var reportTemplate = new ReportPrototype(DateTime.Now);

			var stats = new StatsBuilder(location);

			var stopper = new Stopwatch();
			stopper.Start();

			IEnumerable<Sample> samples = ReadAllSamples(location);

			stopper.Stop();

			stats.AddDuration(stopper.Elapsed);
			stats.AddCount((uint)samples.Count());

			var report = reportTemplate.Clone(stats.Build());

			Store(new List<string> { report });

			return samples;
		}

		private static void Store(List<string> reports)
		{
			var file = $"samplesRead.{DateTime.Now.AsFileName()}.txt";

			var logger = new LoggerFactory().Create(file);

			reports.ForEach(report => logger.Log(report));
		}

		public static IEnumerable<Sample> ReadAllSamples(string location)
		{
			var schema = ExtractSchema(location);

			var reader = Readers.Borrow(schema);

			var channelType = ExtractChannel(location);
			var channel = ChanelFactory.Create(channelType);

			IEnumerable<Sample> samples;
			using (StreamReader stream = channel.Connect(location))
			{
				samples = reader.Read(stream);
			}

			Readers.Release(reader);
			return samples;
		}

		private static string ExtractSchema(string location)
		{
			return location.Split('.').Last();
		}

		private static string ExtractChannel(string location)
		{
			return location.Split(':').First();
		}
	}
}
