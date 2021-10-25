﻿using PbLab.DesignPatterns.Services;
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
			Mass = mass;
		}

		public DateTimeOffset TimeStamp { get; set; }

		public MassValue Mass { get; set; }

		public int Id { get; }
	}
}