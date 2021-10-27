using System;

namespace PbLab.DesignPatterns.Model
{
	public class MassValue	
	{
		private static MassValue _zero = new MassValue(0, MassUnit.Gram);

		private static MassValue _none = new MassValue() { Value = -1, Unit = MassUnit.Gram };

		public static MassValue Zero => _zero;

		public static MassValue None => _none;

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