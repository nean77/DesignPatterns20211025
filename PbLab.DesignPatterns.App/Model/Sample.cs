using PbLab.DesignPatterns.Services;
using System;

namespace PbLab.DesignPatterns.Model
{
	public class Sample
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

		public DateTimeOffset TimeStamp { get; protected set; }

		public MassValue Mass { get; protected set; }

		public int Id { get; }
	}
}