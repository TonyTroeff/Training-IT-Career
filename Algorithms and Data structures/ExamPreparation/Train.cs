namespace TrainsSkeleton
{
    class Train
    {
        public Train(int number, string name, string type, int cars)
        {
            this.Number = number;
            this.Name = name;
            this.Type = type;
            this.Cars = cars;
        }

        public int Number { get; }
        public string Name { get; }
        public string Type { get; }
        public int Cars { get; }

        public override string ToString() => $"{this.Number} {this.Name} {this.Type} {this.Cars}";
    }
}
