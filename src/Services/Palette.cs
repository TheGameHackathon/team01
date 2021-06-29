using System;
using System.Drawing;
using System.Linq;
namespace thegame.Services
{
    public class Palette
    {
        public static Color[] colors;
        public Palette(int colorCount)
        {
            
        }

        public static string ConvertColor(Color color)
        {
            var index = Array.IndexOf(colors, color);
            return $"color{index}";
        }
    }
}