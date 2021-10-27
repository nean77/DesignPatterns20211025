using PbLab.DesignPatterns.Model;
using System;
using System.Collections.Generic;

namespace PbLab.DesignPatterns.Execution
{
	public class BulkParallerScheduler : IScheduler<string, Sample>
	{
		public IEnumerable<Sample> Schedule(IEnumerable<string> collection, Func<string, IEnumerable<Sample>> processor)
		{
			// makes groupd of 5 and then paraller each group

			throw new NotImplementedException();
		}
	}
}
