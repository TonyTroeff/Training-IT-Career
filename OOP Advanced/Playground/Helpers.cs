namespace Playground
{
    public static class Helpers
    {
        public static int CountGreaterElements<T>(List<T> list, T value, IComparer<T>? comparer = null)
        {
            if (comparer == null) comparer = Comparer<T>.Default;

            int ans = 0;
            foreach (T element in list)
            {
                int comparisonResult = comparer.Compare(element, value);
                if (comparisonResult > 0) ans++;
            }

            return ans;
        }

        public static void DoNotDoThisEver<T>()
        {
            if (typeof(T) == typeof(int))
            {
                Console.WriteLine("This is an integer.");
            }
            else if (typeof(T) == typeof(string))
            {
                Console.WriteLine("This is a string");
            }
        }

        // How will this work if we cannot instantiate (directly) the interface???
        public static void PrintOnConsole(IPrintable printable)
        {
            string printMessage = printable.Print();
            Console.WriteLine(printMessage);
        }
    }
}
