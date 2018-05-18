using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Project.Generics.Exersise;

namespace Main_Project
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine(string.Join(",", union.Items));
            
        }
    }
}
