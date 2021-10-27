using System;
using System.Collections.Generic;
using System.Linq;

namespace PbLab.DesignPatterns.Execution
{
	public class ParallerScheduler<TCollectionItem, TResult> : IScheduler<TCollectionItem, TResult>
    {
        public IEnumerable<TResult> Schedule(IEnumerable<TCollectionItem> collection, Func<TCollectionItem, IEnumerable<TResult>> processor)
        {
            return collection.AsParallel().SelectMany(processor).ToArray();
        }
    }
}
