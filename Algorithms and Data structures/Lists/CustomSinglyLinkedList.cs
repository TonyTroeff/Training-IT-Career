using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class CustomSinglyLinkedList : IEnumerable<int>
    {
        private Node _start;
        private Node _end;

        public int Count { get; private set; }

        public int this[int index]
        {
            get => this.GetNodeAt(index).Value;
            set => this.GetNodeAt(index).Value = value;
        }

        public void Add(int element)
        {
            Node newNode = new Node { Value = element };
            
            if (this.Count == 0) this._start = newNode;
            else this._end.Next = newNode;

            this._end = newNode;
            this.Count++;
        }

        public void Insert(int index, int element)
        {
            if (index == this.Count)
            {
                this.Add(element);
                return;
            }

            this.ValidateIndex(index);

            Node newNode = new Node { Value = element };

            if (index == 0)
            {
                newNode.Next = this._start;
                this._start = newNode;
            }
            else
            {
                Node predecessor = GetNodeAt(index - 1);
                newNode.Next = predecessor.Next;
                predecessor.Next = newNode;
            }

            this.Count++;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            if (this.Count == 1)
            {
                this._start = null;
                this._end = null;
            }
            else if (index == 0)
            {
                this._start = this._start.Next;
            }
            else
            {
                Node predecessor = this.GetNodeAt(index - 1);
                predecessor.Next = predecessor.Next.Next;

                if (index == this.Count - 1) this._end = predecessor;
            }

            this.Count--;
        }

        public IEnumerator<int> GetEnumerator()
        {
            Node iter = this._start;
            while (iter != null)
            {
                yield return iter.Value;
                iter = iter.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private Node GetNodeAt(int index)
        {
            this.ValidateIndex(index);

            Node iter = this._start;
            for (int i = 0; i < index; i++)
                iter = iter.Next;

            return iter;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count) throw new ArgumentOutOfRangeException("Index is out of range!");
        }

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
