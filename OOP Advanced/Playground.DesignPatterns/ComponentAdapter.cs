using Playground.DesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.DesignPatterns
{
    public class ComponentAdapter : IComponent
    {
        // How to implement the "Decorator" design pattern?
        private readonly IBeverage _wrappedBeverage;

        public ComponentAdapter(IBeverage wrappedBeverage)
        {
            this._wrappedBeverage = wrappedBeverage;
        }

        public void DoSomeWork()
        {
            string description = this._wrappedBeverage.Describe();
            Console.WriteLine(description);
        }
    }
}
