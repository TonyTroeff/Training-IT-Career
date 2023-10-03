namespace AnimalKingdom.Interfaces
{
    public interface IAnimal : IMakeNoise, IMakeTrick
    {
        string Perform();
    }
}
