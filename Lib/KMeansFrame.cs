using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace Lib
{
    public class KMeansFrame
    {
        public KMeansFrame(Image<Rgba32> frame, List<ColorPoint> centroids, ColorPoint center)
        {
            Frame = frame;
            Centroids = centroids;
            Center = center;
        }

        public Image<Rgba32> Frame { get; set; }
        public List<ColorPoint> Centroids { get; set; }
        public ColorPoint Center { get; set; }
    }
}
