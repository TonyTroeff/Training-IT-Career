namespace TrainsSkeleton
{
    class Deque<T>
    {
        private T[] _array = new T[4];
        private int _startIndex = 0;

        public int Count { get; private set; }

        public void AddFront(T item)
        {
            // 1. Grow the underlying array (if this is necessary)
            if (this.Count == this._array.Length) this.Grow();

            // 2. Add the element at a corresponding position within the underlying array
            int arrIndex = this.GetArrayIndex(-1);
            this._array[arrIndex] = item;
            this._startIndex = arrIndex;

            // 3. Increase count
            this.Count++;
        }

        public void AddBack(T item)
        {
            // 1. Grow the underlying array (if this is necessary)
            if (this.Count == this._array.Length) this.Grow();

            // 2. Add the element at a corresponding position within the underlying array
            int arrIndex = this.GetArrayIndex(this.Count);
            this._array[arrIndex] = item;

            // 3. Increase count
            this.Count++;
        }

        public T GetFront()
        {
            if (this.Count == 0) return default;
            return this._array[GetArrayIndex(0)];
        }

        public T GetBack()
        {
            if (this.Count == 0) return default;
            return this._array[GetArrayIndex(this.Count - 1)];
        }

        public T RemoveFront()
        {
            T elementToDequeue = this.GetFront();

            if (this.Count == 1) this._startIndex = 0;
            else this._startIndex = this.GetArrayIndex(1);

            this.Count--;

            return elementToDequeue;
        }

        public T RemoveBack()
        {
            T elementToDequeue = this.GetBack();
            this.Count--;

            return elementToDequeue;
        }

        private int GetArrayIndex(int position)
        {
            int normalizedIndex = (this._startIndex + position) % this._array.Length;
            if (normalizedIndex < 0) normalizedIndex += this._array.Length;

            return normalizedIndex;
        }

        private void Grow()
        {
            T[] newArray = new T[this._array.Length * 2];
            for (int i = 0; i < this.Count; i++)
                newArray[i] = this._array[this.GetArrayIndex(i)];

            this._array = newArray;
        }
    }

    /*
    // Second approach.
    class Deque<T>
    {
        private readonly List<T> _list = new List<T>();

        public int Count => this._list.Count;

        public void AddFront(T item) => this._list.Insert(0, item);

        public void AddBack(T item) => this._list.Add(item);

        public T GetFront()
        {
            if (this.Count == 0) return default;
            return this._list[0];
        }

        public T GetBack()
        {
            if (this.Count == 0) return default;
            return this._list[this.Count - 1];
        }

        public T RemoveFront()
        {
            T frontElement = this.GetFront();
            this._list.RemoveAt(0);
            return frontElement;
        }

        public T RemoveBack()
        {
            T backElement = this.GetBack();
            this._list.RemoveAt(this._list.Count - 1);
            return backElement;
        }
    }
    */

    /*
    // First approach.
    // This approach is not generalized. It will work only for this problem.
    // In the real world, such an implementation is impractical.
    class Deque<T>
    {
        private readonly Stack<T> _front = new Stack<T>(); // freight 
        private readonly Stack<T> _back = new Stack<T>(); // passenger

        public int FrontCount => this._front.Count;
        public int BackCount => this._back.Count;
        public int Count => this.FrontCount + this.BackCount;

        public void AddFront(T item) => this._front.Push(item);

        public void AddBack(T item) => this._back.Push(item);

        public T GetFront()
        {
            if (this.FrontCount == 0) return default;
            return this._front.Peek();
        }

        public T GetBack()
        {
            if (this.BackCount == 0) return default;
            return this._back.Peek();
        }

        public T RemoveFront() => this._front.Pop();

        public T RemoveBack() => this._back.Pop();
    }
    */
}
