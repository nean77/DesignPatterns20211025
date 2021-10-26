using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbLab.DesignPatterns.Tools
{
    public class ObjectsPool<TType>
    {
        private readonly IFactory<TType> _readerFactory;

        private int _limit = 10;
        readonly IDictionary<string, Stack<TType>> _free = new Dictionary<string, Stack<TType>>();
        readonly ISet<Borrowed> _borrowed = new HashSet<Borrowed>();

        public ObjectsPool(IFactory<TType> readerFactory)
        {
            _readerFactory = readerFactory;
        }

        public void Release(TType used)
        {
            var known = _borrowed.FirstOrDefault(b => b.Reader.Equals(used));

            if (known == null)
            {
                return;
            }

            _borrowed.Remove(known);
            _free[known.Key].Push(known.Reader);
        }

        public TType Borrow(string key)
        {
            if (_free.ContainsKey(key) == false)
            {
                Initialize(key);
            }

            if (_free[key].Count == 0)
            {
                throw new Exception("pool is empty");
            }

            var returned = _free[key].Pop();

            _borrowed.Add(new Borrowed(key, returned));

            return returned;
        }

        private TType Factorize(string key)
        {
            return _readerFactory.Create(key);
        }

        private void Initialize(string key)
        {
            _free.Add(key, new Stack<TType>(new[] { Factorize(key), Factorize(key) }));
        }

        private class Borrowed
        {
            public Borrowed(string key, TType reader)
            {
                Key = key;
                Reader = reader;
            }
            public string Key { get; }

            public TType Reader { get; }
        }
    }
}
