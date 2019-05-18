using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Rectangle : IShape, IMovable
    {
        private int x, y, width, height;
        public void SetPosition(int x, int y) // IShape 
        {
            this.x = x;
            this.y = y;
        }
        public int CalculateSurface() // IShape
        {
            return this.width * this.height;
        }
        public void Move(int deltaX, int deltaY) // IMovable
        {
            this.x += deltaX;
            this.y += deltaY;
        }
    }

}
