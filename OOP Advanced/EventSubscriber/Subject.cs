using EventSubscriber.Interfaces;

namespace EventSubscriber
{
    public class Subject : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void Notify()
        {
            foreach (var observer in this._observers)
            {
                observer.Update(123);
            }
        }

        public void Register(IObserver observer)
        {
            if (observer != null) this._observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            if (observer != null) this._observers.Remove(observer);
        }
    }
}
