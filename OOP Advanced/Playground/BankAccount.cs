namespace Playground
{
    public class BankAccount
    {
        // Using the arrow syntax (computed properties), a new instance will be created for each invocation.
        public static BankAccount DemoAccount1 => new BankAccount { ID = 4444 };

        // Using the initialization syntax, the same instance will be returned over and  over again.
        public static BankAccount DemoAccount2 { get; } = new BankAccount { ID = 4444 };

        public static BankAccount GetDemoAccount() => new BankAccount { ID = 4444 };

        public int ID { get; set; }
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }
    }
}
