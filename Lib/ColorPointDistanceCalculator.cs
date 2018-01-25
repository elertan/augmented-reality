using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class ColorPointDistanceCalculator
    {
        public static double GetEuclidianDistance(ColorPoint @from, ColorPoint to)
        {
            // Compute the Euclidian distance between two pixel in the 2D-space
            return Math.Sqrt(Math.Pow(@from.X - to.X, 2) +
                             Math.Pow(@from.Y - to.Y, 2));
        }

        public static double GetEuclidianColor(ColorPoint @from, ColorPoint to)
        {
            // Compute the Euclidian distance between two colors in the 3D-space
            return Math.Sqrt(Math.Pow(Math.Abs(@from.Color.R - to.Color.R), 2) +
                             Math.Pow(Math.Abs(@from.Color.G - to.Color.G), 2) +
                             Math.Pow(Math.Abs(@from.Color.B - to.Color.B), 2));
        }
    }
}
