using System;
using System.Collections.Generic;

namespace PbLab.DesignPatterns.Execution
{
    public class ConcurrentScheduler<TCollectionItem, TResult> : IScheduler<TCollectionItem, TResult>
    {
        public IEnumerable<TResult> Schedule(IEnumerable<TCollectionItem> collection, Func<TCollectionItem, IEnumerable<TResult>> processor)
        {
            // use threads to execute jobes concurrently
            throw new NotImplementedException();
        }
    }
}
