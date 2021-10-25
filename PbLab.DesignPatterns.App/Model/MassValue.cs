using System;

namespace PbLab.DesignPatterns.Model
{
	public class MassValue	
	{
		public MassValue()
		{

		}

		public MassValue(decimal value, MassUnit unit)
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("mass must be positive");
			}

			Value = value;
			Unit = unit;
		}

		public decimal Value { get; set; }

		public MassUnit Unit { get; set; }

		public static MassValue Parse(string mass)
		{
			var parts = mass.Split(' ');

			var builder = new MassValueBuilder();
			builder.AddUnit(parts[1]);
			builder.AddValue(parts[0]);

			return builder.Build();
		}

		public override string ToString()
		{
			return Value.ToString() + " " + Unit;
		}
	}
}