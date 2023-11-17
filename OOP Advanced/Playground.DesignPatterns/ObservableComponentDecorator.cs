using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public class ObservableComponentDecorator : IComponent
    {
        private readonly List<Action<int>> _subscriptions = new List<Action<int>>();
        private readonly IComponent _decoratedComponent;

        private int _invocationsCount = 0;

        public ObservableComponentDecorator(IComponent decoratedComponent)
        {
            this._decoratedComponent = decoratedComponent;
        }

        public int SubscribeToChange(Action<int> subscription)
        {
            this._subscriptions.Add(subscription);
            return this._subscriptions.Count - 1;
        }

        public void DoSomeWork()
        {
            int invocationIndex = Interlocked.Increment(ref this._invocationsCount);
            foreach (var subscription in this._subscriptions)
                subscription(invocationIndex);

            this._decoratedComponent.DoSomeWork();
        }
    }
}
