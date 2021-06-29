using System;
using System.Drawing;
using thegame.Models;

namespace thegame.Services
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] field;

        private Random random;
        public Palette Palette { get; set; }

        public Field(int width, int height, Palette palette)
        {
            Width = width;
            Height = height;
            field = new Cell[width, height];
            random = new Random();
            Palette = palette;

            CreateField();
        }

        private void CreateField()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    field[x, y] = new Cell(
                        Guid.NewGuid().ToString(), 
                        new Point(x, y), 
                        Palette.colors[random.Next(0, Palette.colors.Length)]
                        );
                }
            }
        }

        public Cell[] ConvertInOneLine()
        {
            var cells = new Cell[Width * Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cells[x * Width + y] = field[x, y];
                }
            }

            return cells;
        }
    }
}