namespace Playground.Math
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The `Dictionary` type implements the Open-Closed principle by exposing a constructor that accepts `IEqualityComparer<TKey>` parameter allowing extension of the hash code generation and quality comparison capabilities.
            Dictionary<Vector, string> map = new Dictionary<Vector, string>();

            var key1 = new Vector(1, 2, 3);
            var key2 = new Vector(1, 2, 3);
            map[key1] = "Test";
            Console.WriteLine($"Are the two keys equivalent? Ans: {key1.Equals(key2)}");
            Console.WriteLine($"Does the dictionary understand them as equivalent? Ans: {map.ContainsKey(key2)}");

            Console.WriteLine();
            var points = new[] { new Vector(2), new Vector(5), new Vector(3, 2), new Vector(4, 4), new Vector(1, -2), new Vector(6, -3) }; 

            var horizontalComparer = new HorizontalPlacementComparer();
            var verticalComparer = new VerticalPlacementComparer();
            var distanceFromOriginComparer = new DistanceFromOriginComparer();

            for (int i = 0; i < points.Length;i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    Console.WriteLine($"Compare horizontally point #{i + 1} and point #{j + 1}: {horizontalComparer.Compare(points[i], points[j])}");
                    Console.WriteLine($"Compare vertically point #{i + 1} and point #{j + 1}: {verticalComparer.Compare(points[i], points[j])}");
                    Console.WriteLine($"Is point #{i + 1} closer to origin than point #{j + 1}: {distanceFromOriginComparer.Compare(points[i], points[j])}");
                    Console.WriteLine();
                }
            }

            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine($"Hash code based on distance between point #{i + 1} and origin: {distanceFromOriginComparer.GetHashCode(points[i])}");
            }
        }
    }
}