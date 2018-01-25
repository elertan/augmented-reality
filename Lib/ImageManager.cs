using System;
using System.IO;
using System.Reflection;
using SixLabors.ImageSharp;

namespace Lib
{
    public class ImageManager
    {
        public static Image<Rgba32> GetSampleImage()
        {
            return Image.Load(Path.Combine(Assembly.GetExecutingAssembly().Location, @"../../../../../Lib/Assets/small-image.jpg"));
        }

        public static void SaveImage(Image<Rgba32> image, Assembly assembly, string filename = "result")
        {
            var dirPath = Path.Combine(Assembly.GetExecutingAssembly().Location, $"../../../../../Lib/Assets/{assembly.FullName}");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            var outputPath = Path.Combine(dirPath, filename + ".jpg");
            using (var fs = File.OpenWrite(outputPath))
            {
                image.SaveAsJpeg(fs);
            }
        }
    }
}
