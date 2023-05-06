namespace Life
{
    public class BankAccount
    {
		private int id;
        private double balance;

        public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public double Balance
		{
			get { return balance; }
			set { balance = value; }
		}

		public void Deposit(double amount)
		{
			this.Balance += amount;
		}

		public void Withdraw(double amount)
		{
			this.Balance -= amount;
		}

        public override string ToString()
        {
            return $"Account ID{this.Id}, balance {this.Balance:f2}";
        }
    }
}
