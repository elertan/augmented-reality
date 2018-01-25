using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace Lib
{
    public class ImageScaler
    {
        public Image<Rgba32> ScaleTo(Image<Rgba32> image, float scale, InterpolationMethod im)
        {
            var scaledImage = new Image<Rgba32>((int)Math.Ceiling(scale * image.Width), (int)Math.Ceiling(scale * image.Height));

            for (var y = 0; y < scaledImage.Height; ++y)
            {
                for (var x = 0; x < scaledImage.Width; ++x)
                {
                    var sourceX = (int) Math.Round(x / scale);
                    var sourceY = (int) Math.Round(y / scale);

                    switch (im)
                    {
                        case InterpolationMethod.NearestNeighbour:
                            scaledImage[x, y] = image[sourceX, sourceY];
                            break;
                        case InterpolationMethod.Billinear:
                            var floorX = (int) Math.Floor(x / scale);
                            var floorY = (int) Math.Floor(y / scale);

                            var ceilX = (int) Math.Ceiling(x / scale);
                            var ceilY = (int) Math.Ceiling(y / scale);

                            var fractionX = x / scale - floorX;
                            var fractionY = y / scale - floorY;
                            var fractionXRev = 1 - fractionX;
                            var fractionYRev = 1 - fractionY;

                            var c1 = image[floorX, floorY];
                            var c2 = image[ceilX, floorY];
                            var c3 = image[floorX, ceilY];
                            var c4 = image[ceilX, ceilY];

                            // Red
                            var red1 = (byte) (fractionXRev * c1.R + fractionX * c2.R);
                            var red2 = (byte) (fractionXRev * c3.R + fractionX * c4.R);
                            var r = (byte) (fractionYRev * red1 + fractionY * red2);
                            // Green
                            var green1 = (byte) (fractionXRev * c1.G + fractionX * c2.G);
                            var green2 = (byte) (fractionXRev * c3.G + fractionX * c4.G);
                            var g = (byte) (fractionYRev * green1 + fractionY * green2);
                            // Blue
                            var blue1 = (byte) (fractionXRev * c1.B + fractionX * c2.B);
                            var blue2 = (byte) (fractionXRev * c3.B + fractionX * c4.B);
                            var b = (byte) (fractionYRev * blue1 + fractionY * blue2);

                            scaledImage[x, y] = new Rgba32(r, g, b);
                            break;
                    }
                }
            }

            return scaledImage;
        }
    }
}
