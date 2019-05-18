using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Creature
    {
        protected string Name { get; private set; }

        protected void Walk()
        {
            Console.WriteLine("Walking ...");
        }
        private void Talk()
        {
            Console.WriteLine("I am creature ...");
        }
    }

}
