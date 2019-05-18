using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle obj = new Circle();
            Console.ReadLine();

            //==========================

            Dog joe = new Dog(6, "Labrador");
            Console.WriteLine(joe.Breed);
            //joe.Walk(); // is protected and can not be invoked
            //joe.Talk(); // is private and can not be invoked
            //joe.Name = "Rex"; // Name cannot be accessed here
            Console.ReadLine();

            //==========================

            // Create 5 years old animal
            Animal animal = new Animal(5);
            Console.WriteLine(animal.Age);
            animal.Sleep();

            // Create a bulldog, 3 years old
            Dog dog = new Dog(3, "Bulldog");
            dog.Sleep();
            dog.Age = 4;
            Console.WriteLine("Age: {0}", dog.Age);
            Console.WriteLine("Breed: {0}", dog.Breed);
            dog.WagTail();
            Console.ReadLine();

            //==========================

            Polymorphism.Person[] persons =
            {
                new Polymorphism.Person(),
                new Polymorphism.Trainer(),
                new Polymorphism.Student()
            };

            foreach (Polymorphism.Person p in persons)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            Console.WriteLine(GetTrainerByReference(new Polymorphism.Trainer()));
            Console.WriteLine(GetPersonByReference(new Polymorphism.Trainer()));

            Console.ReadLine();

            //==========================

            Interface.IPerson[] iPersons =
            {
                new Interface.Person(),
                new Interface.Trainer(),
                new Interface.Student()
            };

            foreach (Interface.IPerson p in iPersons)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();
            Console.WriteLine(GetIPersonByReference(new Interface.Student()));
            Console.ReadLine();

            //==========================

            Abstract.Person[] aPersons =
           {
                //new Abstract.Person(),
                new Abstract.Trainer(),
                new Abstract.Student()
            };

            foreach (Abstract.Person p in aPersons)
            {
                Console.WriteLine(p);
            }
            Console.ReadLine();
        }

        static Polymorphism.Trainer GetTrainerByReference(Polymorphism.Trainer trainer)
        {
            return trainer;
        }

        static Polymorphism.Person GetPersonByReference(Polymorphism.Person person)
        {
            return person;
        }

        static Interface.IPerson GetIPersonByReference(Interface.IPerson person)
        {
            return person;
        }
    }
}
