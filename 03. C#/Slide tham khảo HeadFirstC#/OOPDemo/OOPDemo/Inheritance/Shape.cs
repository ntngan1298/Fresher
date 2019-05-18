using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Shape
    {
        public Shape()
        {
            Console.WriteLine("Shape initialized");
        }
    }

    public class Circle : Shape
    {
        public Circle():base()
        {
            Console.WriteLine("Circle initialized");
        }
    }
}
