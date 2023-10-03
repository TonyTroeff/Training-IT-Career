namespace Playground.Math
{
    using System.Diagnostics.CodeAnalysis;
    using Math = System.Math;

    public class DistanceFromOriginComparer : IComparer<Vector>, IEqualityComparer<Vector>
    {
        public int Compare(Vector? x, Vector? y)
        {
            if (x is null) throw new ArgumentNullException(nameof(x));
            if (y is null) throw new ArgumentNullException(nameof(y));

            int absoluteDistanceX = CalculateAbsoluteDistance(x);
            int absoluteDistanceY = CalculateAbsoluteDistance(y);

            return absoluteDistanceX.CompareTo(absoluteDistanceY);
        }

        public bool Equals(Vector? x, Vector? y)
        {
            if (x is null) throw new ArgumentNullException(nameof(x));
            if (y is null) throw new ArgumentNullException(nameof(y));

            return CalculateAbsoluteDistance(x) == CalculateAbsoluteDistance(y);
        }

        public int GetHashCode([DisallowNull] Vector obj)
            => HashCode.Combine(CalculateAbsoluteDistance(obj));

        private int CalculateAbsoluteDistance(Vector v) => Math.Abs(v.X) + Math.Abs(v.Y) + Math.Abs(v.Z);
    }
}
