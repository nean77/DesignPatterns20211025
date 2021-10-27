using System;
using System.Collections.Generic;
using System.Linq;

namespace PbLab.DesignPatterns.Execution
{
	public class LinearScheduler<TCollectionItem, TResult> : IScheduler<TCollectionItem, TResult>
    {
        public IEnumerable<TResult> Schedule(IEnumerable<TCollectionItem> collection, Func<TCollectionItem, IEnumerable<TResult>> processor)
        {
            return collection.SelectMany(item => processor(item)).ToArray();
        }
    }
}
