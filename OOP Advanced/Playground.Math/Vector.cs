namespace Playground.Math
{
    public class Vector : IEquatable<Vector?>
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Vector(int x)
        {
            this.X = x;
        }

        public Vector(int x, int y)
            : this(x)
        {
            this.Y = y;
        }

        public Vector(int x, int y, int z)
            : this(x, y)
        {
            this.Z = z;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj is Vector v) return this.Equals(v);
            return false;
        }

        public bool Equals(Vector? other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;
            return other is not null && this.X == other.X && this.Y == other.Y && this.Z == other.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y, this.Z);
        }
    }
}
