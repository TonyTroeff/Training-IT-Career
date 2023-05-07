using System.Text;

namespace CarDealer
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(this.Engine.ToString());

            if (this.Weight.HasValue)
                sb.AppendLine($"  Weight: {this.Weight.Value}");
            else
                sb.AppendLine($"  Weight: n/a");

            if (!string.IsNullOrWhiteSpace(this.Color))
                sb.AppendLine($"  Color: {this.Color}");
            else
                sb.AppendLine($"  Color: n/a");

            return sb.ToString();
        }
    }
}
