using System;
using System.Drawing;
namespace thegame.Services
{
    public class Palette
    {
        public Color[] Colors;

        public Palette(int colorCount)
        {
            var random = new Random();
            Colors = new Color[colorCount];
            for (var i = 0; i < colorCount; i++)
            {
                Colors[i] = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            }

        }

        public string ConvertColor(Color color)
        {
            var index = Array.IndexOf(Colors, color);
            return $"color{index + 1}";
        }
    }
}