namespace PreliminaryExam
{
    public class Coffee
    {
        public Coffee(string type, double price)
        {
            this.Type = type;
            this.Price = price;
        }

        public string Type { get; }
        public double Price { get; }

        public override string ToString() => $"Coffee {this.Type} costs {this.Price:f2} lv.";
    }
}
