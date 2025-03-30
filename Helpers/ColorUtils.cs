using System.Drawing;

namespace BarriolympicsRadzen.Helpers
{
    public static class ColorUtils
    {

        public static string LightenColor(string hex, float lightnessFactor)
        {
            // Convert hex to Color
            Color color = ColorTranslator.FromHtml(hex);

            // Convert to HSL
            float h, s, l;
            ColorToHSL(color, out h, out s, out l);

            // Increase lightness
            l = Math.Min(l + lightnessFactor, 1f);

            // Convert back to Color and then to hex
            Color lightenedColor = HSLToColor(h, s, l);
            return ColorTranslator.ToHtml(lightenedColor);
        }
        public static string DarkenColor(string hex, float darknessFactor)
        {
            // Convert hex to Color
            Color color = ColorTranslator.FromHtml(hex);

            // Convert to HSL
            float h, s, l;
            ColorToHSL(color, out h, out s, out l);

            // Decrease lightness
            l = Math.Max(l - darknessFactor, 0f);

            // Convert back to Color and then to hex
            Color darkenedColor = HSLToColor(h, s, l);
            return ColorTranslator.ToHtml(darkenedColor);
        }

        private static void ColorToHSL(Color color, out float h, out float s, out float l)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            l = (max + min) / 2f;

            if (max == min)
            {
                h = s = 0; // Achromatic
            }
            else
            {
                float d = max - min;
                s = l > 0.5f ? d / (2f - max - min) : d / (max + min);

                if (max == r)
                    h = (g - b) / d + (g < b ? 6f : 0f);
                else if (max == g)
                    h = (b - r) / d + 2f;
                else
                    h = (r - g) / d + 4f;

                h /= 6f;
            }
        }

        private static Color HSLToColor(float h, float s, float l)
        {
            if (s == 0)
            {
                int gray = (int)(l * 255);
                return Color.FromArgb(gray, gray, gray);
            }

            float q = l < 0.5f ? l * (1 + s) : l + s - l * s;
            float p = 2 * l - q;

            float r = HueToRGB(p, q, h + 1f / 3f);
            float g = HueToRGB(p, q, h);
            float b = HueToRGB(p, q, h - 1f / 3f);

            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        private static float HueToRGB(float p, float q, float t)
        {
            if (t < 0f) t += 1f;
            if (t > 1f) t -= 1f;
            if (t < 1f / 6f) return p + (q - p) * 6f * t;
            if (t < 1f / 2f) return q;
            if (t < 2f / 3f) return p + (q - p) * (2f / 3f - t) * 6f;
            return p;
        }
    }
}

