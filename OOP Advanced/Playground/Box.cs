namespace Playground
{
    public class Box<TValue>
    {
        private Stack<TValue> _stack = new Stack<TValue>();

        public void Add(TValue value)
        {
            this._stack.Push(value);
        }

        public TValue Remove()
        {
            return this._stack.Pop();
        }
    }
}
