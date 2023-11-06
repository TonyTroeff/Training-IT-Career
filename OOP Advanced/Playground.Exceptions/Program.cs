namespace Playground.Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Solve();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"An invalid operation exception was thrown. Its message was: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An exception occurred but we do not have more information about it. Its message was: {e.Message}");

                // The next line will re-throw the same exception.
                // throw;

                // The next line will re-throw the same exception BUT the stack trace will be changed. (this is not recommended)
                // throw e;
                // throw new ApplicationException(e.Message);

                // The next line will throw a new exception but the original one is passed as an `initial exception` and its stack trace will be preserved.
                // throw new ApplicationException("Unhandled exception occurred!", e);
            }
            finally
            {
                Console.WriteLine("This is a message from the `finally` block.");
            }

            Console.WriteLine("The program will exit gracefully! :)");
        }

        static void Solve()
        {
            var text = ReadText();
            Console.WriteLine($"Hello! The entered text was: {text}");
        }

        static string ReadText()
        {
            var text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
                throw new InvalidOperationException("Invalid text was entered.");

            if (text[0] == '-')
                throw new FormatException("The entered text cannot start with a minus sign.");

            return text;
        }
    }
}