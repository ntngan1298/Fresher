﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public interface IShape
    {
        void SetPosition(int x, int y);
        int CalculateSurface();
    }
    public interface IMovable
    {
        void Move(int deltaX, int deltaY);
    }
    public interface IResizable
    {
        void Resize(int weight);
        void Resize(int weightX, int weightY);
        void ResizeByX(int weightX);
        void ResizeByY(int weightY);
    }

}
