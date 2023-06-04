using System;

namespace Queues
{
    public class CustomQueue
    {
        private int[] _array = new int[4];
        private int _startIndex = 0;

        public int Count { get; private set; }

        public void Enqueue(int element)
        {
            // 1. Grow the underlying array (if this is necessary)
            if (this.Count == this._array.Length) this.Grow();

            // 2. Add the element at a corresponding position within the underlying array
            int arrIndex = this.GetArrayIndex(this.Count);
            this._array[arrIndex] = element;

            // 3. Increase count
            this.Count++;
        }

        public int Dequeue()
        {
            this.EnsureNotEmpty();

            int elementToDequeue = this.Peek();
            if (this.Count == 1) this._startIndex = 0;
            else this._startIndex = this.GetArrayIndex(1);

            this.Count--;

            return elementToDequeue;
        }

        public int Peek()
        {
            this.EnsureNotEmpty();
            return this._array[this._startIndex];
        }

        private int GetArrayIndex(int position)
            => (this._startIndex + position) % this._array.Length;

        private void Grow()
        {
            int[] newArray = new int[this._array.Length * 2];
            for (int i = 0; i < this.Count; i++)
                newArray[i] = this._array[this.GetArrayIndex(i)];

            this._array = newArray;
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0) throw new InvalidOperationException("The queue is empty!");
        }
    }
}
