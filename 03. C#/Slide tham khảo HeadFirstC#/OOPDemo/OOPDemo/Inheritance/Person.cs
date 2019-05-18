using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Employee : Person
    {
        public string Company { get; set; }
        public double Salary { get; set; }
    }

    public class Student : Person
    {
        public string School { get; set; }
    }
}
