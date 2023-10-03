using AnimalKingdom.Interfaces;

namespace AnimalKingdom
{
    public abstract class BaseAnimal : IAnimal
    {
        public abstract string MakeNoise();
        public abstract string MakeTrick();
        public string Perform() => $"{this.MakeNoise()}{Environment.NewLine}{this.MakeTrick()}";
    }
}