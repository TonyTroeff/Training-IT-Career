using System.Diagnostics.CodeAnalysis;

namespace Playground.Math
{
    public class VerticalPlacementComparer : IComparer<Vector>, IEqualityComparer<Vector>
    {
        public int Compare(Vector? x, Vector? y)
        {
            if (x is null) throw new ArgumentNullException(nameof(x));
            if (y is null) throw new ArgumentNullException(nameof(y));

            return x.Y.CompareTo(y.Y);
        }

        public bool Equals(Vector? x, Vector? y)
        {
            if (x is null) throw new ArgumentNullException(nameof(x));
            if (y is null) throw new ArgumentNullException(nameof(y));

            return x.Y == y.Y;
        }

        public int GetHashCode([DisallowNull] Vector obj) => HashCode.Combine(obj.Y);
    }
}
