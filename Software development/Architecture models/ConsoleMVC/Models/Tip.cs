namespace ConsoleMVC.Models
{
    public class Tip
    {
        private double _percentage;

        public double Amount { get; init; }
        public double Percentage
        {
            get => this._percentage;
            init => this._percentage = Math.Clamp(value, 0, 1);
        }

        public double Value => this.Amount * this.Percentage;
        public double Total => this.Amount + this.Value;
    }
}
