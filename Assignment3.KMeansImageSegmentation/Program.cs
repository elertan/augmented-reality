using System;
using System.Reflection;
using Lib;

namespace Assignment3.KMeansImageSegmentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = ImageManager.GetSampleImage("tiger");

            var imageSegmenter = new ImageSegmenter();
            var segmentedImage = imageSegmenter.SegmentImage(image, k: 12);

            ImageManager.SaveImage(segmentedImage, Assembly.GetExecutingAssembly());
        }
    }
}
