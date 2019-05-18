using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Dog : Animal
    {
        private string breed;
        public Dog(int age, string breed) : base(age)
        {
            this.breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public void WagTail()
        {
            //base.Talk(); //cannot be invoked here (it is private)
            Console.WriteLine("Tail wagging...");
        }
    }
}
