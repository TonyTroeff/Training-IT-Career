using System.Text;

namespace CarDealer
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");

            if (this.Displacement.HasValue)
                sb.AppendLine($"    Displacement: {this.Displacement.Value}");
            else
                sb.AppendLine($"    Displacement: n/a");
            
            if (!string.IsNullOrWhiteSpace(this.Efficiency))
                sb.AppendLine($"    Efficiency: {this.Efficiency}");
            else
                sb.AppendLine($"    Efficiency: n/a");

            return sb.ToString();
        }
    }
}
