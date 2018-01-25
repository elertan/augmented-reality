using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SixLabors.ImageSharp;

namespace Lib
{
    public class ImageSegmenter
    {
        /// <summary>
        /// Segments an image into a certain amount of clusters.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public Image<Rgba32> SegmentImage(Image<Rgba32> image, int k)
        {
            if (k < 2)
            {
                throw new ArgumentException("The amount of clusters cannot be less than 2.", nameof(k));
            }

            // Make copy
            var segmentedImage = image.CloneAs<Rgba32>();
            var size = image.Width * image.Height;
            // Store colors and locations
            var colorPoints = new List<ColorPoint>(size);
            for (var y = 0; y < image.Height; ++y)
            {
                for (var x = 0; x < image.Width; ++x)
                {
                    colorPoints.Add(new ColorPoint(x, y, image[x, y]));
                }
            }
            var centroids = GenerateCentroids(segmentedImage, k);
            var finishedCentroids = new List<ColorPoint>();

            // Store each points assigned cluster index
            var clusterLocations = new List<int>(size);

            Console.WriteLine(DateTime.Now.ToLongTimeString());
            while (finishedCentroids.Count < centroids.Count)
            {
                Console.WriteLine("Iteration\n");
                clusterLocations.Clear();

                for (var i = 0; i < size; ++i)
                {
                    var currentCp = colorPoints[i];
                    var first = centroids.Select(cp => new KeyValuePair<double,ColorPoint>(ColorPointDistanceCalculator.GetEuclidianColor(currentCp, cp), cp)).OrderBy(kvp => kvp.Key).First();
                    clusterLocations.Add(centroids.IndexOf(first.Value));
                }

                var totalXs = new List<long>(centroids.Count);
                var totalYs = new List<long>(centroids.Count);

                // Prepare list for use
                foreach (var _ in centroids)
                {
                    totalXs.Add(0);
                    totalYs.Add(0);
                }

                for (var i = 0; i < clusterLocations.Count; ++i)
                {
                    totalXs[clusterLocations[i]] += colorPoints[i].X;
                    totalYs[clusterLocations[i]] += colorPoints[i].Y;
                }

                foreach (var centroid in centroids)
                {
                    var index = centroids.IndexOf(centroid);
                    if (finishedCentroids.Contains(centroid)) continue;

                    var newX = (int) Math.Round((double)(totalXs[index] / clusterLocations.Count(cl => cl == index)));
                    var newY = (int) Math.Round((double)(totalYs[index] / clusterLocations.Count(cl => cl == index)));

                    if (centroid.X == newX
                        && centroid.Y == newY)
                    {
                        finishedCentroids.Add(centroid);
                        Console.WriteLine($"Centroid {index} finished.");
                        continue;
                    }

                    Console.WriteLine($"Centroid {index} ({centroid.X}, {centroid.Y}) moved to ({newX}, {newY})");
                    centroid.X = newX;
                    centroid.Y = newY;
                }

            }
            Console.WriteLine(DateTime.Now.ToLongTimeString());

            for (var i = 0; i < colorPoints.Count; ++i)
            {
                var colorPoint = colorPoints[i];
                segmentedImage[colorPoint.X, colorPoint.Y] = centroids[clusterLocations[i]].Color;
            }

            return segmentedImage;
        }

        private List<ColorPoint> GenerateCentroids(Image<Rgba32> image, int amount)
        {
            var colorPoints = new List<ColorPoint>(amount);
            var random = new Random();
            for (var i = 0; i < amount; ++i)
            {
                int randomX;
                int randomY;

                // Make sure the random position will be unique for the superpixel
                while (true)
                {
                    randomX = random.Next(0, image.Width);
                    randomY = random.Next(0, image.Height);

                    if (!colorPoints.Any(cp => cp.X == randomX && cp.Y == randomY))
                    {
                        break;
                    }
                }

                var colorPoint = new ColorPoint(randomX, randomY, image[randomX, randomY]);
                colorPoints.Add(colorPoint);
            }

            return colorPoints;
        }
    }
}
