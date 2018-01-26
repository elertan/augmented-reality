using System;

namespace Lib
{
    public class AngleConverter
    {
        private double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
    }
}