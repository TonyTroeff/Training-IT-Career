using System;
using System.Collections.Generic;
using System.Text;

namespace InstancesCounter
{
    public class Person
    {
        public static int Count { get; private set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;

            Count++;
        }

        public string Name { get; }
        public int Age { get; }
    }
}
