using System;
using System.Drawing;
namespace thegame.Services
{
    public class Palette
    {
        public Color[] colors;
        private Random random;

        public Palette(int colorCount)
        {
            random = new Random();
            colors = new Color[colorCount];
            for (int i = 0; i < colorCount; i++)
            {
                colors[i] = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            }

        }

        public string ConvertColor(Color color)
        {
            var index = Array.IndexOf(colors, color);
            return $"color{index + 1}";
        }

        public Color ConvertColor(string color)
        {
            var index = int.Parse(color.Substring(5));
            return colors[index - 1];
        }
    }
}