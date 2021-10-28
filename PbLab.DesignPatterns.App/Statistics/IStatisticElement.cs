using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Statistics
{
	// mark visited object, invitation for visit
	public interface IStatisticElement
	{
		// tell who can visit
		void Accept(IStatisticsCreator creator);
	}
}
