using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRootQueries
{
    public static class SquareRootCalculator
    {
        private static Dictionary<double, double> _memo = new Dictionary<double, double>();

        /*static SquareRootCalculator()
        {
            _memo = new Dictionary<double, double>();
        }*/

        public static double Calculate(double number)
        {
            if (_memo.ContainsKey(number)) return _memo[number];

            double result = Math.Sqrt(number);
            _memo[number] = result;
            return result;
        }
    }
}
