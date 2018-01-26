using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lib
{
    public static class ExtensionMethods
    {
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            if (val.CompareTo(max) > 0) return max;
            return val;
        }
        
        /// <summary>
        /// AngleBetween - the angle between 2 vectors
        /// </summary>
        /// <returns>
        /// Returns the the angle in degrees between vector1 and vector2
        /// </returns>
        /// <param name="vector1"> The first Vector </param>
        /// <param name="vector2"> The second Vector </param>
        public static double AngleBetween(this Vector2 vector1, Vector2 vector2)
        {
//            double sin = vector1.X * vector2.Y - vector2.X * vector1.Y;  
//            double cos = vector1.X * vector2.X + vector1.Y * vector2.Y;
            
            return Math.Atan2(vector2.Y - vector1.Y, vector2.X - vector1.X);

//            return Math.Atan2(sin, cos) * (180 / Math.PI);
        }
    }
}
