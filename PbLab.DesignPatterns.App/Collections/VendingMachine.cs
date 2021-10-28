using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PbLab.DesignPatterns.Collections
{
	public class CompanyWorker
	{
		public  void TopUp(IDictionary<ItemType, Queue<Item>> machine, IEnumerable<Item> newItems)
		{

		}

		public void FindOutDated(IDictionary<ItemType, Queue<Item>> machine)
		{
			var outdated = machine.SelectMany(group => group.Value).Where(item => item.ExpDate < DateTime.Now).ToArray();
		}

		public void TopUp(IVendingMachine machine, IEnumerable<Item> newItems)
		{
			foreach(var item in newItems)
			{
				machine.Add(item);
			}
		}

		public void FindOutDated(IVendingMachine machine)
		{
			foreach(var item in machine)
			{
				if(item.ExpDate < DateTime.Now)
				{

				}
			}

			var outdated = machine.Where(item => item.ExpDate < DateTime.Now).ToArray();
		}
	}

	internal class VendingMachine : IVendingMachine
	{
		private IDictionary<ItemType, Queue<Item>> _memory = new Dictionary<ItemType, Queue<Item>>();

		public void Add(Item item)
		{
			if(!_memory.ContainsKey(item.Type))
			{
				_memory.Add(item.Type, new Queue<Item>());
			}

			_memory[item.Type].Enqueue(item);
		}

		public Item Get(ItemType type)
		{
			if(!_memory.ContainsKey(type) || !_memory[type].Any())
			{
				throw new ItemNotFoundException();
			}

			var result = _memory[type].Dequeue();

			return result;
		}

		public IEnumerator<Item> GetEnumerator()
		{
			var flat = _memory.SelectMany(group => group.Value).OrderBy(item => item.ExpDate).ToList();

			return flat.GetEnumerator();

			// or custom enumerator
			return new GenericEnumerator<Item>(flat);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private class GenericEnumerator<T> : IEnumerator<T>
		{
			private IEnumerator<T> itemsEnumerator;

			public GenericEnumerator(IEnumerable<T> items)
			{
				itemsEnumerator = items.GetEnumerator();
			}

			public T Current => itemsEnumerator.Current;

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				itemsEnumerator.Dispose();
			}

			public bool MoveNext()
			{
				return itemsEnumerator.MoveNext();
			}

			public void Reset()
			{
				itemsEnumerator.Reset();
			}
		}
	}

	[Serializable]
	internal class ItemNotFoundException : Exception
	{
		public ItemNotFoundException()
		{
		}

		public ItemNotFoundException(string message) : base(message)
		{
		}

		public ItemNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}

	public interface IVendingMachine : IEnumerable<Item>
	{
		void Add(Item item);

		Item Get(ItemType type);
	}

	public class Item
	{
		public IEnumerable<string> Ingrediens { get; }

		public string Name { get; }

		public ItemType Type { get; }

		public DateTime ExpDate { get; }
	}

	public enum ItemType
	{
		Fanta,
		Cola,
		Sprite
	}
}
