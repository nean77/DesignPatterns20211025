using PbLab.DesignPatterns.Model;
using System.Collections.Generic;

namespace PbLab.DesignPatterns.Statistics
{
	public class AmountsStatistics: IStatisticsCreator
	{
		private IDictionary<MassUnit, int> _amounts = new Dictionary<MassUnit, int>();

		public void Analyze(Sample sample)
		{
			Collect(sample);
		}

		public int GetAmount(MassUnit unit)
		{
			return _amounts.ContainsKey(unit) ? _amounts[unit] : 0;
		}

		private void Collect(Sample sample)
		{
			if(!_amounts.ContainsKey(sample.Mass.Unit))
			{
				_amounts.Add(sample.Mass.Unit, 0);
			}

			_amounts[sample.Mass.Unit]++;
		}
	}
}