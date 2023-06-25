using System;
using System.Collections.Generic;
using System.Linq;

namespace UnionAndIntersection
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        static List<int> Union(List<int> first, List<int> second)
        {
            HashSet<int> unionSet = new HashSet<int>();
            foreach (int el in first) unionSet.Add(el);
            foreach (int el in second) unionSet.Add(el);

            return unionSet.ToList();
        }

        static List<int> Intersect1(List<int> first, List<int> second)
        {
            HashSet<int> intersectSet = new HashSet<int>();

            HashSet<int> firstSet = new HashSet<int>(first);
            foreach (int el in second)
            {
                if (firstSet.Contains(el)) intersectSet.Add(el);
            }

            return intersectSet.ToList();
        }

        static List<int> Intersect2(List<int> first, List<int> second)
        {
            List<int> result = new List<int>();

            HashSet<int> firstSet = new HashSet<int>(first);
            HashSet<int> secondSet = new HashSet<int>(second);
            foreach (int el in firstSet)
            {
                if (secondSet.Contains(el)) result.Add(el);
            }

            return result;
        }
    }
}
