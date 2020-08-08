using System.Drawing;

namespace Hsluv.SystemDrawing
{
    public static class RgbColorExtensions
    {
        /// <summary>
        /// Converts the color into h (hue), s (saturation), and l (lightness)
        /// components, adjusted to fit human color perception.
        /// </summary>
        public static HsluvColor ToHsluv(this Color color)
        {
            var hsluv = Hsluv.HsluvConverter.RgbToHsluv(new double[] { color.R / 255f, color.G / 255f, color.B / 255f });

            return HsluvColor.FromHsl(hsluv[0], hsluv[1], hsluv[2]);
        }
    }
}
