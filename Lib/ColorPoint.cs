using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace Lib
{
    public class ColorPoint
    {
        public ColorPoint(int x, int y, Rgba32 color)
        {
            X = x;
            Y = y;
            Color = color;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Rgba32 Color { get; set; }
    }
}
