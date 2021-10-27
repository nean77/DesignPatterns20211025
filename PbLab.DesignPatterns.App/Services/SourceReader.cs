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
		private IScheduler<string, Sample> _defaultScheduler = new LinearScheduler<string, Sample>();
		private IChanelFactory _chanelFactory;
		private ObjectsPool<ISamplesReader> _readers;
		private static Lazy<SourceReader> _instance = new Lazy<SourceReader>(() => new SourceReader(new ObjectsPool<ISamplesReader>(new ReaderFactory()), new ChanelFactory(), new LinearScheduler<string, Sample>()));


		protected SourceReader(ObjectsPool<ISamplesReader> readers, IChanelFactory chanelFactory, IScheduler<string, Sample> defaultScheduler = null)
		{
			_defaultScheduler = defaultScheduler ?? new LinearScheduler<string, Sample>();
			_chanelFactory = chanelFactory;
			_readers = readers;
		}

		public static SourceReader Instance => _instance.Value;

        public IEnumerable<Sample> ReadAllSources(IEnumerable<string> paths, IScheduler<string, Sample> scheduler = null)
        {
			scheduler = scheduler ?? _defaultScheduler;

			return scheduler.Schedule(paths, location => ProcessSource(location));
        }

		private IEnumerable<Sample> ProcessSource(string location)
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

		private void Store(List<string> reports)
		{
			var file = $"samplesRead.{DateTime.Now.AsFileName()}.txt";

			var logger = new LoggerFactory().Create(file);

			reports.ForEach(report => logger.Log(report));
		}

		public IEnumerable<Sample> ReadAllSamples(string location)
		{
			var schema = ExtractSchema(location);
			ISamplesReader reader = GetReader(schema);

			var channelType = ExtractChannel(location);
			var channel = _chanelFactory.Create(channelType);

			IEnumerable<Sample> samples;
			using (StreamReader stream = channel.Connect(location))
			{
				samples = reader.Read(stream);
			}

			ReturnReader(reader);			
			return samples;
		}

		protected virtual void ReturnReader(ISamplesReader reader)
		{
			_readers.Release(reader);
		}

		protected virtual ISamplesReader GetReader(string schema)
		{
			return _readers.Borrow(schema);
		}

		protected virtual string ExtractSchema(string location)
		{
			return location.Split('.').Last();
		}

		protected virtual string ExtractChannel(string location)
		{
			return location.Split(':').First();
		}
	}
}
