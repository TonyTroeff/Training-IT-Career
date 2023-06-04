using System;
using System.Collections.Generic;
using System.Text;

namespace Queues
{
    public class CustomLinkedQueue
    {
        private Node _head, _tail;

        public int Count { get; private set; }

        public void Enqueue(int element)
        {
            Node newNode = new Node { Value = element };
            if (this.Count == 0) this._head = newNode;
            else this._tail.Next = newNode;

            this._tail = newNode;
            this.Count++;
        }

        public int Dequeue()
        {
            this.EnsureNotEmpty();

            int elementToDequeue = this.Peek();
            if (this.Count == 1)
            {
                this._head = null;
                this._tail = null;
            }
            else
                this._head = this._head.Next;

            this.Count--;
            return elementToDequeue;
        }

        public int Peek()
        {
            this.EnsureNotEmpty();
            return this._head.Value;
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0) throw new InvalidOperationException("The queue is empty!");
        }

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
