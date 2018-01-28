using System;
using System.Reflection;
using Lib;

namespace Assignment4.UnwarpingAlgorithmOmnidirectionalToPerspective
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = ImageManager.GetSampleImage("omni");

            var imageUnwarper = new ImageUnwarper();
            var unwarpedImage = imageUnwarper.UnwarpImage(image, 50, 240);

            Console.WriteLine("Done");
            ImageManager.SaveImage(unwarpedImage, Assembly.GetExecutingAssembly());
        }
    }
}
