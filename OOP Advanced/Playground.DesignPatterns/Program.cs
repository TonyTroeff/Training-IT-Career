using Playground.DesignPatterns.Interfaces;
using System.Buffers;

namespace Playground.DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Here we can see "Singleton" + "Factory method" design patterns application.
            // int[] array = ArrayPool<int>.Shared.Rent(100);

            DemonstrateComposition();
        }

        static void DemonstrateComposition()
        {
            IBeverageFactory beverageFactory = new WaterFactory();
            IBeverage beverage = beverageFactory.CreateBeverage("Tony");

            IComponent component1 = new Component("#1");
            IComponent component2 = new Component("#2");
            IComponent component3 = new Component("#3");
            IComponent component4 = new ComponentAdapter(beverage);

            ComponentComposite root = new ComponentComposite("root");
            root.AddChild(component1);
            root.AddChild(component2);

            ComponentComposite secondLevel = new ComponentComposite("second_level_1");

            IComponent wrappedComponent = component1;
            for (int i = 0; i < 5; i++) wrappedComponent = new ComponentDecorator(wrappedComponent);

            secondLevel.AddChild(component4);
            secondLevel.AddChild(wrappedComponent);
            secondLevel.AddChild(component3);

            root.AddChild(secondLevel);

            root.DoSomeWork();
        }

        static void DemonstrateStaticMethodCreator()
        {
            // The constructor SHOULD be private.
            // Book obj1 = new Book("Design Patterns");

            // 1. I recommend using it if there is some kind of (business) logic related to the instantiation process.
            // 2. It helps us to implement "TryParse"-like functionalities

            Book book = Book.Create("Design Patterns");
        }

        static void DemonstrateFactory()
        {
            // Although the implementations of the `IBeverageFactory` interface are pretty straightforward, there is no other meaningful way to incorporate the instantiation logic for a hierarchy of types.
            // We cannot use generic methods in most of the cases because the different implementations may have different needs (for information) and constructors.
            IBeverageFactory waterFactory = new WaterFactory();
            IBeverageFactory coffeeFactory = new CoffeeFactory();

            OperateWithFactory(waterFactory);
            OperateWithFactory(coffeeFactory);

            static void OperateWithFactory(IBeverageFactory factory)
            {
                Console.Write("Enter the name of the customer: ");
                string customerName = Console.ReadLine();

                IBeverage beverage = factory.CreateBeverage(customerName);
                Console.WriteLine($"{beverage.CustomerName} bought {beverage.Name} for {beverage.Price:f2}$.");
                Console.WriteLine($"Detailed description of the beverage: {beverage.Describe()}");
            }
        }

        static void DemonstrateSingleton()
        {
            // We are following the solution guidelines for implementing the "Singleton" design pattern - the constructor MUST be private.
            // SingletonResource obj1 = new SingletonResource();
            // SingletonResource obj2 = new SingletonResource();
            // SingletonResource obj3 = new SingletonResource();

            Console.WriteLine($"Number of created instances for the SingletonResource type: {SingletonResource.NumberOfInstances}");

            bool singletonReferencesAreSame = object.ReferenceEquals(SingletonResource.Instance, SingletonResource.Instance);
            Console.WriteLine($"This is a correct implementation of the Singleton pattern: {singletonReferencesAreSame}");
            Console.WriteLine(SingletonResource.Instance.Name);

            Console.WriteLine($"Number of created instances for the SingletonResource type: {SingletonResource.NumberOfInstances}");
        }
    }
}