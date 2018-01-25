using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace Lib
{
    public class ColorConverter
    {
        public YuvColor Rgba32ToYuvColor(Rgba32 c)
        {
            var y = (short)(c.R * 0.299 + c.G * 0.587 + c.B * 0.114);
            var u = (short)(c.R * -0.168736 + c.G * -0.331264 + c.B * 0.5 + 128);
            var v = (short)(c.R * 0.5 + c.G * -0.418688 + c.B * -0.081312 + 128);

            return new YuvColor
            {
                Y = (byte)y,
                U = (byte)u,
                V = (byte)v
            };
        }

        public Rgba32 YuvColorToRgba32(YuvColor c)
        {
            const short lowestVal = 0;
            const short highestVal = 255;

            var r = (short)(c.Y + 1.370705 * (c.V - 128));
            var g = (short)(c.Y - 0.698001 * (c.V - 128) - 0.337633 * (c.U - 128));
            var b = (short)(c.Y + 1.732446 * (c.U - 128));

            r = r.Clamp(lowestVal, highestVal);
            g = g.Clamp(lowestVal, highestVal);
            b = b.Clamp(lowestVal, highestVal);

            return new Rgba32((byte)r, (byte)g, (byte)b);
        }

        public Rgba32 Rgba32ToBlackAndWhiteRgba32(Rgba32 c)
        {
            var average = (byte)((c.R + c.G + c.B) / 3);
            return new Rgba32(average, average, average);
        }

        public YuvColor YuvColorToBlackAndWhiteYuvColor(YuvColor c)
        {
            return new YuvColor {Y = c.Y, U = 128, V = 128};
        }
    }
}
