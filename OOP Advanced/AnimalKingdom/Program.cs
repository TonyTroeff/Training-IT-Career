using AnimalKingdom.Interfaces;

namespace AnimalKingdom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IAnimal animal = new Cat();
            IAnimal animal = new Dog();

            Trainer trainer = new Trainer(animal);
            Console.WriteLine(trainer.Make());
        }
    }
}