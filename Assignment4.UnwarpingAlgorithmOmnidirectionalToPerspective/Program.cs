using System;
using System.Reflection;
using Lib;

namespace Assignment4.UnwarpingAlgorithmOmnidirectionalToPerspective
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = ImageManager.GetSampleImage("omni2");

            var imageUnwarper = new ImageUnwarper();
            var unwarpedImage = imageUnwarper.UnwarpImage(image, 25, 160);

            ImageManager.SaveImage(unwarpedImage, Assembly.GetExecutingAssembly());
        }
    }
}
