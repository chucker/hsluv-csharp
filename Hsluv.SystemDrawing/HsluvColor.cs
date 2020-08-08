using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;

namespace Hsluv.SystemDrawing
{
    /// <summary>
    /// A color with h (hue), s (saturation), and l (lightness) components,
    /// adjusted to fit human color perception.
    /// </summary>
    public struct HsluvColor
    {
        private const int H_MIN = 0;
        private const int H_MAX = 360;
        private const int S_MIN = 0;
        private const int S_MAX = 100;
        private const int L_MIN = 0;
        private const int L_MAX = 100;

        /// <summary>
        /// The hue component of the color.
        /// </summary>
        [Range(H_MIN, H_MAX)]
        public double H { get; }

        /// <summary>
        /// Makes a new color with the new hue, but saturation and lightness
        /// left the same.
        /// </summary>
        public HsluvColor WithH(double h) 
            => new HsluvColor(h, this.S, this.L);

        /// <summary>
        /// The saturation component of the color.
        /// </summary>
        [Range(S_MIN, S_MAX)]
        public double S { get; }

        /// <summary>
        /// Makes a new color with the new saturation, but hue and lightness
        /// left the same.
        /// </summary>
        public HsluvColor WithS(double s)
            => new HsluvColor(this.H, s, this.L);

        /// <summary>
        /// The lightness component of the color.
        /// </summary>
        [Range(L_MIN, L_MAX)]
        public double L { get; }

        /// <summary>
        /// Makes a new color with the new lightness, but hue and saturation
        /// left the same.
        /// </summary>
        public HsluvColor WithL(double l)
            => new HsluvColor(this.H, this.S, l);

        private HsluvColor(double h, double s, double l)
        {
            H = h;
            S = s;
            L = l;
        }

        /// <summary>
        /// Makes a new <see cref="HsluvColor"/> from its components.
        /// <paramref name="h"/> must be between 0 and 360, and
        /// <paramref name="s"/> and <paramref name="l"/> between 0 and 100.
        /// </summary>
        public static HsluvColor FromHsl(double h, double s, double l)
        {
            if (h < H_MIN || h > H_MAX)
            {
                if ((h + 0.1) > H_MIN)
                    h = H_MIN;
                else if ((h - 0.1) <= H_MAX)
                    h = H_MAX;
                throw new ArgumentOutOfRangeException(nameof(h));
            }

            if (s < S_MIN || s > S_MAX)
            {
                if ((s + 0.1) > S_MIN)
                    s = S_MIN;
                else if ((s - 0.1) <= S_MAX)
                    s = S_MAX;
                else
                    throw new ArgumentOutOfRangeException(nameof(s));
            }

            if (l < L_MIN || l > L_MAX)
            {
                if ((l + 0.1) > L_MIN)
                    l = L_MIN;
                else if ((l - 0.1) <= L_MAX)
                    l = L_MAX;
                else
                    throw new ArgumentOutOfRangeException(nameof(l));
            }

            return new HsluvColor ( h, s,  l );
        }

        /// <summary>
        /// Converts the color into r (red), g (green) and b (blue) components.
        /// </summary>
        public Color ToRgb()
        {
            var rgb = Hsluv.HsluvConverter.HsluvToRgb(new[] { H, S, L }.ToList());

            return Color.FromArgb((int)(rgb[0] * 256), (int)(rgb[1] * 256), (int)(rgb[2] * 256));
        }
    }
}
