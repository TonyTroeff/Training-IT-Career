using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class CustomDoublyLinkedList : IEnumerable<int>
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
            else
            {
                this._end.Next = newNode;
                newNode.Previous = this._end;
            }

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
                this._start.Previous = newNode;
                this._start = newNode;
            }
            else
            {
                Node predecessor = GetNodeAt(index - 1);
                Node successor = predecessor.Next;

                newNode.Previous = predecessor;
                newNode.Next = successor;

                predecessor.Next = newNode;
                successor.Previous = newNode;
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
                this._start.Previous = null;
            }
            else
            {
                Node predecessor = this.GetNodeAt(index - 1);
                Node successor = predecessor.Next.Next;

                predecessor.Next = successor;

                if (index == this.Count - 1) this._end = predecessor;
                else successor.Previous = predecessor;
            }

            this.Count--;
        }

        private Node GetNodeAt(int index)
        {
            this.ValidateIndex(index);

            int indexFromEnd = this.Count - 1 - index;

            if (index <= indexFromEnd)
            {
                Node iter = this._start;
                for (int i = 0; i < index; i++)
                    iter = iter.Next;

                return iter;
            }
            else
            {
                Node iter = this._end;
                for (int i = 0; i < indexFromEnd; i++)
                    iter = iter.Previous;

                return iter;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count) throw new ArgumentOutOfRangeException("Index is out of range!");
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

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }
    }
}
