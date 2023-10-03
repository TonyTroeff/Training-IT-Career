using System.Diagnostics.CodeAnalysis;

namespace Playground.Math
{
    public class HorizontalPlacementComparer : IComparer<Vector>, IEqualityComparer<Vector>
    {
        public int Compare(Vector? x, Vector? y)
        {
            if (x is null) throw new ArgumentNullException(nameof(x));
            if (y is null) throw new ArgumentNullException(nameof(y));

            return x.X.CompareTo(y.X);
        }

        public bool Equals(Vector? x, Vector? y)
        {
            if (x is null) throw new ArgumentNullException(nameof(x));
            if (y is null) throw new ArgumentNullException(nameof(y));

            return x.X == y.X;
        }

        public int GetHashCode([DisallowNull] Vector obj) => HashCode.Combine(obj.X);
    }
}
