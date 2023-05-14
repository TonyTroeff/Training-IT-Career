using System;
using System.Collections.Generic;

namespace SquareRootMemoization
{
    internal static class SquareRootCache
    {
        private static Dictionary<double, double> cache = new Dictionary<double, double>();

        internal static double GetSquareRoot(double input)
        {
            if (!cache.ContainsKey(input))
                cache[input] = Math.Sqrt(input);
            return cache[input];
        }
    }
}
