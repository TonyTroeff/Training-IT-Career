using System;
using System.Collections.Generic;
using System.Text;

namespace Stacks
{
    public class CustomLinkedStack
    {
        private Node _top;

        public int Count { get; private set; }

        public void Push(int element)
        {
            Node newNode = new Node { Value = element };

            newNode.Next = this._top;
            this._top = newNode;

            this.Count++;
        }

        public int Pop()
        {
            this.EnsureNotEmpty();

            int removedElement = this.Peek();

            this._top = this._top.Next;
            this.Count--;

            return removedElement;
        }

        public int Peek()
        {
            this.EnsureNotEmpty();
            return this._top.Value;
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0) throw new Exception("Stack is empty!");
        }

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
