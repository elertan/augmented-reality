using System;
using System.Reflection;
using Lib;

namespace Assignment2.BillinearInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = ImageManager.GetSampleImage();

            var imageScaler = new ImageScaler();
            var scaledImage = imageScaler.ScaleTo(image, 10, InterpolationMethod.Billinear);

            ImageManager.SaveImage(scaledImage, Assembly.GetExecutingAssembly());
        }
    }
}
