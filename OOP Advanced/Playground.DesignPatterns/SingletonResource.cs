namespace Playground.DesignPatterns
{
    public class SingletonResource
    {
        // How to implement the "Singleton" design pattern?
        private static SingletonResource? _instance;

        public static SingletonResource Instance
            => _instance ??= new SingletonResource();

        // This is an alternative approach to implement the "Singleton" design pattern.
        // However, it does not provide "lazy initialization" capabilities.
        // public static SingletonResource Instance { get; } = new SingletonResource();

        private static int _numberOfInstances;
        public static int NumberOfInstances => _numberOfInstances;

        public string Name { get; }

        private SingletonResource() 
        {
            this.Name = "This is a singleton resource";

            // This is a thread-safe way of incrementing an integer.
            // _numberOfInstances++;
            Interlocked.Increment(ref _numberOfInstances);
        }
    }
}
