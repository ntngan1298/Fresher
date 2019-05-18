using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.Interface
{
    abstract class MovableShape : IShape, IMovable
    {
        private int x, y;
        public void Move(int deltaX, int deltaY)
        {
            this.x += deltaX;
            this.y += deltaY;
        }
        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public abstract int CalculateSurface();
    }

}
