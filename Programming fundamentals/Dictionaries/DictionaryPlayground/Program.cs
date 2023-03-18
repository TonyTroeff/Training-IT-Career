namespace DictionaryPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            phoneBook.Add("Albena", "0886523518");
            phoneBook.Add("Stefan", "0887651238");

            /*
            // This will throw an exception:
            phoneBook.Add("Albena", "new phone number");
            */

            // This will not:
            phoneBook["Albena"] = "new phone number";
            phoneBook["Petromil"] = "089562103";

            if (phoneBook.ContainsKey("Stefan"))
            {
                Console.WriteLine($"The phone number of Stefan is: {phoneBook["Stefan"]}");
            }

            if (phoneBook.ContainsKey("Richard"))
            {
                Console.WriteLine($"The phone number of Richard is: {phoneBook["Richard"]}");
            }

            /*foreach (KeyValuePair<string, string> kvp in phoneBook)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }*/

            foreach (var (key, value) in phoneBook)
            {
                Console.WriteLine($"{key} => {value}");
            }
        }
    }
}