namespace Playground
{
    public class Scale<T>
    {
        private readonly IComparer<T> _comparer;

        public T Left { get; }
        public T Right { get; }

        public Scale(T left, T right)
            : this(left, right, Comparer<T>.Default)
        {
        }

        public Scale(T left, T right, IComparer<T> comparer)
        {
            this._comparer = comparer;
            this.Left = left;
            this.Right = right;
        }

        public T GetHeavier()
        {
            var comparisonResult = this._comparer.Compare(this.Left, this.Right);
            if (comparisonResult > 0) return this.Left;
            if (comparisonResult < 0) return this.Right;

            return default;
        }
    }
}
