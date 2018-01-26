using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace Lib
{
    public class ImageUnwarper
    {
        public Image<Rgba32> UnwarpImage(Image<Rgba32> omniImage, int blindSpotRadius, int outerRadius)
        {
            var centerX = (int) Math.Round((double) omniImage.Width / 2);
            var centerY = (int) Math.Round((double) omniImage.Height / 2);

            var circumreference = (int) Math.Round((outerRadius - blindSpotRadius) * Math.PI * 2);

            var persImage = new Image<Rgba32>(circumreference, outerRadius - blindSpotRadius);

            for (var y = 0; y < omniImage.Height; ++y)
            {
                for (var x = 0; x < omniImage.Width; ++x)
                {
                    var distanceFromCenter = Math.Sqrt(Math.Pow(x - centerX, 2)
                                                       + Math.Pow(y - centerY, 2));

                    if (distanceFromCenter < blindSpotRadius
                        || distanceFromCenter > outerRadius)
                    {
                        continue;
                    }

                    var radius = distanceFromCenter - blindSpotRadius;
                    
                    
                }
            }

            //for (var y = 0; y < persImage.Height; ++y)
            //{
            //    for (var x = 0; x < persImage.Width; ++x)
            //    {

            //    }
            //}

            //var imageScaler = new ImageScaler();
            //persImage = imageScaler.ScaleTo(persImage, 1, InterpolationMethod.Billinear);

            return persImage;
        }
    }
}
