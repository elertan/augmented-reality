using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using SixLabors.ImageSharp;

namespace Lib
{
    public class ImageUnwarper
    {
        public Image<Rgba32> UnwarpImage(Image<Rgba32> omniImage, int blindSpotRadius, int outerRadius)
        {
            var centerVector = new Vector2((int) Math.Round((double) omniImage.Width / 2),
                (int) Math.Round((double) omniImage.Height / 2));
            
            var circumreference = (int) Math.Round(outerRadius * Math.PI * 2);

            var persImage = new Image<Rgba32>(circumreference, outerRadius);

            for (var y = 0; y < omniImage.Height; ++y)
            {
                for (var x = 0; x < omniImage.Width; ++x)
                {
                    var currentVector = new Vector2(x, y);

                    var distanceFromCenter = Vector2.Distance(centerVector, currentVector);

                    if (distanceFromCenter > outerRadius)
                    {
                        continue;
                    }

                    var angle = centerVector.AngleBetween(currentVector) * (180 / Math.PI);

                    var persX = (int)Math.Round((angle + 180) / 360 * circumreference);
                    var persY = (int)Math.Round(outerRadius - distanceFromCenter);

                    persImage[persX, persY] = omniImage[x, y];
                }
            }

            var imageWithoutBlindSpot = new Image<Rgba32>(circumreference, outerRadius - blindSpotRadius);

            for (var y = 0; y < persImage.Height - blindSpotRadius; ++y)
            {
                for (var x = 0; x < persImage.Width; ++x)
                {
                    imageWithoutBlindSpot[x, y] = persImage[x, y];
                }
            }

            var imageScaler = new ImageScaler();
            persImage = imageScaler.ScaleTo(imageWithoutBlindSpot, 1, InterpolationMethod.Billinear);

            return persImage;
        }
    }
}
