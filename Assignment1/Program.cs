using System;
using System.Reflection;
using Lib;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Performs Rgb to Yuv conversion and back
            var image = ImageManager.GetSampleImage();

            var colorConverter = new ColorConverter();
            for (var y = 0; y < image.Height; ++y)
            {
                for (var x = 0; x < image.Width; ++x)
                {
                    var yuvColor = colorConverter.Rgba32ToYuvColor(image[x, y]);
                    var rgbaColor = colorConverter.YuvColorToRgba32(yuvColor);
                    image[x, y] = rgbaColor;
                }
            }

            ImageManager.SaveImage(image, Assembly.GetExecutingAssembly());
        }
    }
}
