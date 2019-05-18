using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExample
{
    internal class Cat
    {
        private string original;
        private readonly string skin = "Yellow";
        public string Name { get; set; }

        private string _type = "Tam The";
        public string Type
        {
            get { return _type; }
            private set { _type = value; }
        }

        public const double Magic = 3.15;

        public int DOB;

        public Cat():this("Viet Nam")
        {
            //original = "Viet Nam";
        }

        public Cat(string originalArg)
        {
            original = originalArg;
        }

        public Cat(string originalArg, string skinArg)
        {
            original = originalArg;
            skin = skinArg;
        }

        public void Say()
        {
            //skin = "Red";
            Console.WriteLine("Meoooo!");
        }

        public string GetOriginal()
        {
            //Console.WriteLine(original);
            return original;
        }

        public void GetSkin()
        {
            Console.WriteLine(skin);
        }
    }
}
