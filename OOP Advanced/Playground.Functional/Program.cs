namespace Playground.Functional
{
    // We declare delegates here - not within a class (it is possible but not recommended), not within a method.
    // Delegates are like interfaces for methods
    // <access_modifier> delegate <return_type> <delegate_name>(<params_list>);
    public delegate void MyCustomDelegate(int param1, string param2);

    // In most cases we do not need custom delegates because we can use `Action` or `Func`.
    // `Action` is used whenever the function should return `void`.
    // `Action` - this represents a function that does not accept any parameters and returns `void`.
    // `Action<TParam1, TParam2, ..., TParamN>` - this represents a function that accepts N parameters and returns `void` (the maximum possible values for N is 15)
    // `Func` is used whenever the function should return a value.
    // `Func<TReturnType>` - this represents a function that does not accept any parameters and returns a value of type `TReturnType`.
    // `Func<TParam1, TParam2, ..., TParamN, TReturnType>` - this represents a function that accepts N parameters and returns a value of type `TReturnType` (the maximum possible value for N is 15)

    internal class Program
    {
        static void Main(string[] args)
        {
            int x1 = 0, x2 = 0;
            Func<int> generateFunc1 = () => ++x1, generateFunc2 = () => ++x2;
            DynamicGenerator generator = new DynamicGenerator(generateFunc1, generateFunc2);
            for (int i = 0; i < 10; i++) Console.WriteLine(generator.GenerateNumber());

            Console.WriteLine($"Generate function #1 was invoked {x1} times");
            Console.WriteLine($"Generate function #2 was invoked {x2} times");
            Console.WriteLine();

            MyCustomDelegate testMethod = TestMethod;
            testMethod.Invoke(13, "Hello, world!");

            Func<string, int> parseFunc = int.Parse;
            int[] numbers = Console.ReadLine().Split().Select(parseFunc).ToArray();
            int divider = parseFunc(Console.ReadLine());

            // Syntax for anonymous functions:
            // (<parameters>) => <body>
            // delegate (<parameters>) { <body> } - This is rarely used

            // This is a lambda expression:
            // x => x % 2 == 0

            // This is a lambda function/statement:
            // x =>
            // {
            //     return x % 2 == 0;
            // }

            // If there is only one parameter, the parentheses can be omitted.
            // Before each parameter, we can write down its type for better clarity (in most cases this is 

            Action<int> write = Console.WriteLine;

            // These two lines are equivalent:
            // foreach (var num in numbers.Where(x => x % 2 == 0).OrderBy(Math.Abs)) { }
            // foreach (var num in numbers.Where(IsEven).OrderBy(Math.Abs)) { }

            // foreach (var num in numbers.Where(x => x % divider == 0).OrderBy(Math.Abs))
            var divisibilityCondition = new DivisibilityCondition(divider);
            foreach (var num in numbers.Where(divisibilityCondition.IsDivisible).OrderBy(Math.Abs))
            {
                // This can cause a runtime exception if the invoked function is `null`.
                write.Invoke(num);
                
                // The following are equivalent ways to avoid this.
                // write?.Invoke(num);
                // if (write != null) write.Invoke(num);
            }
        }

        static void TestMethod(int param1, string param2)
        {
            Console.WriteLine($"This is an invocation of the TestMethod with parameters: {param1}, {param2}");
        }

        static bool IsEven(int x) => x % 2 == 0;
    }

    interface INumberGenerator
    {
        int GenerateNumber();
    }

    class DynamicGenerator : INumberGenerator
    {
        private readonly Func<int> _generateNumber1;
        private readonly Func<int> _generateNumber2;

        public DynamicGenerator(Func<int> generateNumber1, Func<int> generateNumber2)
        {
            this._generateNumber1 = generateNumber1;
            this._generateNumber2 = generateNumber2;
        }

        public int GenerateNumber() => this._generateNumber1() + this._generateNumber2();
    }

    class DivisibilityCondition
    {
        private readonly int _divider;

        public DivisibilityCondition(int divider)
        {
            this._divider = divider;
        }

        public bool IsDivisible(int x) => x % this._divider == 0;
    }
}