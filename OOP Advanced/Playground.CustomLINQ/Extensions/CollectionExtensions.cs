using System;
using System.Collections.Generic;

namespace Playground.CustomLINQ.Extensions
{
    internal static class CollectionExtensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, bool> filter)
        {
            foreach (var item in collection)
            {
                if (filter(item)) yield return item;
            }
        }

        public static IEnumerable<TTransformation> Select<TElement, TTransformation>(this IEnumerable<TElement> collection, Func<TElement, TTransformation> transform)
        {
            foreach (var item in collection)
                yield return transform(item);
        }

        public static T Min<T>(this IEnumerable<T> collection) => collection.Min(Comparer<T>.Default);

        public static T Min<T>(this IEnumerable<T> collection, IComparer<T> comparer)
            => collection.FindExtreme(comparer, x => x < 0);

        public static T Max<T>(this IEnumerable<T> collection) => collection.Max(Comparer<T>.Default);

        public static T Max<T>(this IEnumerable<T> collection, IComparer<T> comparer)
            => collection.FindExtreme(comparer, x => x > 0);

        private static T FindExtreme<T>(this IEnumerable<T> collection, IComparer<T> comparer, Func<int, bool> compareResultCheck)
        {
            bool isFirstIteration = true;
            T currentExtreme = default;
            foreach (var item in collection)
            {
                if (isFirstIteration)
                {
                    currentExtreme = item;
                    isFirstIteration = false;
                }
                else
                {
                    int compareResult = comparer.Compare(item, currentExtreme);
                    if (compareResultCheck(compareResult))
                    {
                        currentExtreme = item;
                    }
                }
            }

            if (isFirstIteration) throw new InvalidOperationException("Collection is empty");
            return currentExtreme;
        }
    }
}
