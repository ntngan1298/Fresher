using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    public class ReadOnly
    {
        private readonly int size = 20;

        public ReadOnly(int Size)
        {
            size = Size;
        }

        public void ChangeSize()
        {
            //size = 20;
        }

        public void GetSize()
        {
            Console.WriteLine(size);
        }
    }
}
