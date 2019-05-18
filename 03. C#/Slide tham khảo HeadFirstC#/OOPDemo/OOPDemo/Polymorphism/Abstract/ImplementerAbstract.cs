using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.Interface
{
    public class Turtle : Animal
    {
        public override int Speed { get { return 1; } }

        public override string GetName()
        { return "turtle"; }
    }

    public class Cheetah : Animal
    {
        public override int Speed { get { return 100; } }

        public override string GetName()
        { return "cheetah"; }
    }

}
