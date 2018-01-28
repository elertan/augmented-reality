using System;
using System.Reflection;
using Lib;
using SixLabors.ImageSharp;

namespace ProofExam1.Exercise2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var image = ImageManager.GetSampleImage();
            
            ImageManager.SaveImage(ZoomImage(image, 1.5f, 100, 400, 150, 300), Assembly.GetExecutingAssembly());
        }

        private static Image<Rgba32> ZoomImage(Image<Rgba32> image, float zoom, int xMin, int xMax, int yMin, int yMax)
        {
            var newImg = new Image<Rgba32>(xMax - xMin, yMax - yMin);
            for (var y = yMin; y < yMax; ++y)
            {
                for (var x = xMin; x < xMax; ++x)
                {
                    var newY = y - yMin;
                    var newX = x - xMin;

                    newImg[newX, newY] = image[x, y];
                }
            }

            var imageScaler = new ImageScaler();
            return imageScaler.ScaleTo(newImg, zoom, InterpolationMethod.Billinear);
        }
    }
}