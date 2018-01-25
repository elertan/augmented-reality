using System;
using System.Reflection;
using Lib;

namespace Assignment1.YuvToBlackAndWhite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Performs Rgb to Yuv conversion and Yuv to black and white conversion
            var image = ImageManager.GetSampleImage();

            var colorConverter = new ColorConverter();
            for (var y = 0; y < image.Height; ++y)
            {
                for (var x = 0; x < image.Width; ++x)
                {
                    var yuvColor = colorConverter.Rgba32ToYuvColor(image[x, y]);
                    var bAndWYuvColor = colorConverter.YuvColorToBlackAndWhiteYuvColor(yuvColor);
                    var rgbaColor = colorConverter.YuvColorToRgba32(bAndWYuvColor);
                    image[x, y] = rgbaColor;
                }
            }

            ImageManager.SaveImage(image, Assembly.GetExecutingAssembly());
        }
    }
}
