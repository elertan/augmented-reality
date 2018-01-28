using System;
using System.Reflection;
using Lib;
using SixLabors.ImageSharp;

namespace ProofExam1.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = ImageManager.GetSampleImage("tiger");
            
            ImageManager.SaveImage(ApplyGreenScaleFilter(image), Assembly.GetExecutingAssembly());
        }

        private static Image<Rgba32> ApplyGreenScaleFilter(Image<Rgba32> image)
        {
            var newImg = new Image<Rgba32>(image.Width, image.Height);
            for (var y = 0; y < image.Height; ++y)
            {
                for (var x = 0; x < image.Width; ++x)
                {
                    newImg[x, y] = new Rgba32(0, image[x, y].G, 0);
                }
            }

            return newImg;
        }
    }
}