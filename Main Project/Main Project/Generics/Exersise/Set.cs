using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.Generics.Exersise
{
    public class Set<T> where T : IComparable
    {
        private List<T> _collection;

        public List<T> Items => _collection;

        public Set()
        {
            _collection = new List<T>();
        }

        public Set(IEnumerable<T> numbers)
        {
            _collection = numbers.Distinct().ToList();
        }

        public void Add(T item)
        {
            if(!_collection.Contains(item))
                _collection.Add(item);
        }

        public Set<T> IntersectWith(Set<T> other)
        {
            var intersection = _collection.Where(i => other._collection.Contains(i));
            return new Set<T>(intersection);
        }

        public Set<T> UnionWith(Set<T> other)
        {
            var union = new List<T>();
            union.AddRange(_collection);
            union.AddRange(other._collection);
            return new Set<T>(union.Distinct());
        }
    }
}
