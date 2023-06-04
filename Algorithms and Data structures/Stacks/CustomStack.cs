using System;
using System.Collections.Generic;
using System.Text;

namespace Stacks
{
    public class CustomStack
    {
        private int[] _array = new int[4];

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (this.Count == this._array.Length) this.Grow();

            this._array[this.Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            this.EnsureNotEmpty();

            int elementToPop = this.Peek();
            this.Count--;

            return elementToPop;
        }

        public int Peek()
        {
            this.EnsureNotEmpty();
            return this._array[this.Count - 1];
        }

        private void Grow()
        {
            int[] newArray = new int[this._array.Length * 2];
            Array.Copy(this._array, newArray, this._array.Length);

            this._array = newArray;
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0) throw new Exception("Stack is empty!");
        }
    }
}
