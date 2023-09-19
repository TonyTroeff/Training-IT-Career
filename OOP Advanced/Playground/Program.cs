namespace Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = ArrayCreator.CreateArray(10, 1);
            List<int>[] array2 = ArrayCreator.CreateArray<List<int>>(5);

            Scale<string> textScale = new Scale<string>("Monday", "Tuesday");
            Scale<int> numbersScale = new Scale<int>(13, 26);

            Console.WriteLine("Scale examples:");
            Console.WriteLine(textScale.GetHeavier());
            Console.WriteLine(numbersScale.GetHeavier());
            Console.WriteLine();

            Person person1 = new Person();
            person1.Name = "George";
            person1.Age = 20;

            BankAccount demoAccount = BankAccount.DemoAccount1;
            //BankAccount demoAccount = BankAccount.GetDemoAccount();

            BankAccount bankAccount1 = new BankAccount { ID = 1 };
            bankAccount1.Deposit(13.3M);
            person1.BankAccounts.Add(bankAccount1);

            BankAccount bankAccount2 = new BankAccount { ID = 2 };
            bankAccount2.Deposit(1532.91M);
            person1.BankAccounts.Add(bankAccount2);

            Person person2 = new Person();
            person2.Name = "Jessica";
            person2.Age = 18;

            string introduction1 = person1.IntroduceYourself();
            Console.WriteLine(introduction1);
            Console.WriteLine(person1.GetBalance());

            string introduction2 = person2.IntroduceYourself();
            Console.WriteLine(introduction2);
            Console.WriteLine(person2.GetBalance());

            Pair<int> p1 = new Pair<int>(13, 50);
            int p1First = p1.First;
            int p1Second = p1.Second;

            Pair p2 = new Pair { First = "text", Second = 19 };
            int p2First = (int)p2.First;
            var p2Second = p2.Second;
        }
    }
}