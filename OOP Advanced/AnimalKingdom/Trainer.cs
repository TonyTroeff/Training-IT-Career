using AnimalKingdom.Interfaces;

namespace AnimalKingdom
{
    public class Trainer
    {
        private readonly IAnimal _animal;

        public Trainer(IAnimal animal)
        {
            this._animal = animal;
        }

        public string Make() => this._animal.Perform();
    }
}
