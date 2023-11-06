namespace Playground.Communication
{
    internal class Program
    {
        public static event Func<int, string> Event1;
        public static event Func<int, string> Event2;

        static void Main(string[] args)
        {
            Func<int, string> func1 = new Func<int, string>(x => x.ToString());
            Func<int, string> func2 = (x) => $"From lambda expression: {x}";

            func1 += func2;
            Console.WriteLine(func1(15));

            Event1 += (x) =>
            {
                Console.WriteLine("Lambda statement was invoked!");
                return $"From lambda statement: {x}";
            };
            Event1 += NumberTransformation;
            Event1 += func2;

            // If we uncomment the next line, the `NumberTransformation` method will not be invoked.
            // MyEvent -= NumberTransformation;

            for (int i = 0; i < 10; i++)
            {
                string result = Event1(13);
                Console.WriteLine(result);
            }

            if (Event2 != null) Event2(13);

            var eventHolder = new CommunicationController();
            eventHolder.Event += func2;

            // We cannot invoke an event from outside of the class that defines it!
            // eventHolder.Event(13);

            eventHolder.Func += func2;
            Console.WriteLine(eventHolder.Func(25));
        }

        static string NumberTransformation(int num)
        {
            Console.WriteLine("Method was invoked!");
            return $"From method: {num}";
        }
    }

    internal class CommunicationController
    {
        public event EventHandler<int> Event;
        public Func<int, string> Func { get; set; }
    }

    internal interface IInterface
    {
        Func<int, string> NumberTransformation { get; }
    }
}