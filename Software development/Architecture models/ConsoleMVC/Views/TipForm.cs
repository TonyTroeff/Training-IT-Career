namespace ConsoleMVC.Views
{
    public class TipForm
    {
        public double Amount { get; private set; }
        public double TipPercentage { get; private set; }

        public void Submit()
        {
            Console.WriteLine("Enter the amount of the meal:");
            this.Amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the percent you want to tip: ");
            this.TipPercentage = double.Parse(Console.ReadLine());
        }
    }
}
