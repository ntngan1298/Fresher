using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.Abstract
{
    public abstract class Person
    {
        public abstract void PrintName();
    }
    public class Trainer : Person
    {
        public override void PrintName()
        {
            Console.WriteLine("I am a trainer.");
        }
    }
    public class Student : Person
    {
        public override void PrintName()
        {
            Console.WriteLine("I am a student.");
        }
    }

}
