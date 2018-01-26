using System;
using System.Reflection;
using Lib;

namespace Assignment3.KMeansImageSegmentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = ImageManager.GetSampleImage("image-colors2");

            var imageSegmenter = new ImageSegmenter();
            var segmentedImage = imageSegmenter.SegmentImage(image, k: 24);

            ImageManager.SaveImage(segmentedImage, Assembly.GetExecutingAssembly());
        }
    }
}
