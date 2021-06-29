using System;
using System.Drawing;

namespace thegame.Services
{
    public class Palette
    {
        private Random random;
        public Color[] colors;

        public Palette(int colorCount)
        {
            random = new Random();
            for(int i = 0; i < colorCount; i++)
            {
                colors[i] = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            }
        }
    }
}