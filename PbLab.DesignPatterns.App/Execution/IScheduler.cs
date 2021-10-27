using System;
using System.Collections.Generic;

namespace PbLab.DesignPatterns.Execution
{
	public interface IScheduler<TCollectionItem, TResult>
    {
        IEnumerable<TResult> Schedule(IEnumerable<TCollectionItem> collection, Func<TCollectionItem, IEnumerable<TResult>> processor);
    }
}
