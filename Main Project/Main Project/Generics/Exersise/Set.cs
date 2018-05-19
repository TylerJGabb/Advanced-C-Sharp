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
        public List<T> Items { get; }

        public Set()
        {
            Items = new List<T>();
        }

        public Set(IEnumerable<T> numbers)
        {
            Items = numbers.Distinct().ToList();
        }

        public void Add(T item)
        {
            if(!Items.Contains(item))
                Items.Add(item);
        }

        public Set<T> IntersectWith(Set<T> other)
        {
            var intersection = Items.Where(i => other.Items.Contains(i));
            return new Set<T>(intersection);
        }

        public Set<T> UnionWith(Set<T> other)
        {
            var union = new List<T>();
            union.AddRange(Items);
            union.AddRange(other.Items);
            return new Set<T>(union.Distinct());
        }

        public static void Demo()
        {
            var s1 = new Set<int>();
            var s2 = new Set<int>();

            s1.Add(1);
            s1.Add(1);
            s1.Add(4);
            s2.Add(5);
            s2.Add(4);
            s2.Add(3);

            var union = s1.UnionWith(s2);
            union.Items.Sort();

            var intersection = s1.IntersectWith(s2);

            Console.WriteLine("union: " + string.Join(",", union.Items));
            Console.WriteLine($"intersection: {string.Join(",", intersection.Items)}");
        }
    }
}
