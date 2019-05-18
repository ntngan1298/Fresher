using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.Interface
{
    public abstract class Animal : IComparable<Animal>
    {
        // Abstract methods
        public abstract string GetName();
        public abstract int Speed { get; }
        // Non-abstract method
        public override string ToString()
        {
            return "I am " + this.GetName();
        }
        // Interface method
        public int CompareTo(Animal other)
        {
            return this.Speed.CompareTo(other.Speed);
        }
    }

}
