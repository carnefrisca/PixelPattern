using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PixelArt
{
    static class PatternManager
    {
        public static void CreatePattern(this Texture2D texture, int[][] pattern, Color[] colors)
        {
            int bitmapW = pattern[0].Length;
            int bitmapH = pattern.Length;

            Color[] color = new Color[texture.Width * texture.Height];

            for (int yy = 0; yy < bitmapH; yy++)
            {
                for (int xx = 0; xx < bitmapW; xx++)
                {
                    if (pattern[yy][xx] != 0)
                        color[xx + (yy * bitmapW)] = colors[pattern[yy][xx]];

                    if (pattern[yy][xx] == 0)
                        color[xx + (yy * bitmapW)] = colors[pattern[yy][xx]];
                }

            }

            texture.SetData(color);
        }

        public static Color ToColor(this string hexString)
        {
            if (hexString.StartsWith("#"))
                hexString = hexString.Substring(1);
            uint hex = uint.Parse(hexString, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            Color color = Color.White;
            if (hexString.Length == 8)
            {
                color.A = (byte)(hex >> 24);
                color.R = (byte)(hex >> 16);
                color.G = (byte)(hex >> 8);
                color.B = (byte)(hex);
            }
            else if (hexString.Length == 6)
            {
                color.R = (byte)(hex >> 16);
                color.G = (byte)(hex >> 8);
                color.B = (byte)(hex);
            }
            else
            {
                throw new InvalidOperationException("Invald hex representation of an ARGB or RGB color value.");
            }
            return color;
        }
    }
}
