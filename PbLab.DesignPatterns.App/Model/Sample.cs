using PbLab.DesignPatterns.Services;
using PbLab.DesignPatterns.Statistics;
using System;

namespace PbLab.DesignPatterns.Model
{
	public class Sample : IStatisticElement
	{
		public Sample()
		{
			Id = IdGenerator.Instance.Next(); 
		}

		public Sample(DateTimeOffset timeStamp, MassValue mass)
			: this()
		{
			TimeStamp = timeStamp;
			Mass = mass ?? MassValue.Zero;
		}

		public DateTimeOffset TimeStamp { get; set; }

		public MassValue Mass { get; set; }

		public int Id { get; }

		public void Accept(IStatisticsCreator creator)
		{
			// show itself to visitor
			creator.Analyze(this);
		}
	}
}