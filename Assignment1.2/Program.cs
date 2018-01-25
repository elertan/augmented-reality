using System;
using System.Reflection;
using Lib;

namespace Assignment1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Performs rgb to black and white rgb conversion
            var image = ImageManager.GetSampleImage();

            var colorConverter = new ColorConverter();
            for (var y = 0; y < image.Height; ++y)
            {
                for (var x = 0; x < image.Width; ++x)
                {
                    var rgbaColor = colorConverter.Rgba32ToBlackAndWhiteRgba32(image[x, y]);
                    image[x, y] = rgbaColor;
                }
            }

            ImageManager.SaveImage(image, Assembly.GetExecutingAssembly());
        }
    }
}
