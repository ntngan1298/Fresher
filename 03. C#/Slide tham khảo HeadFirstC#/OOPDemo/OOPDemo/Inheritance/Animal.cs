using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Animal:Creature
    {
        private int age;
        public Animal(int age)
        {
            this.age = age;
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public void Sleep()
        {
            //base.Walk(); //can be invoked here
            //base.Talk(); //cannot be invoked here
            //string name = this.Name; //can be read but cannot be modified here
            //this.Name = "Animal";
            Console.WriteLine("I'm sleeping!");
        }
    }


}
