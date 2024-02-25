namespace ConsoleMVC.Views
{
    public class TipView
    {
        public double Tip { get; init; }
        public double Total { get; init; }

        public void Render()
        {
            Console.WriteLine($"Your tip is {this.Tip:C}");
            Console.WriteLine($"The total will be {this.Total:C}");
        }
    }
}
