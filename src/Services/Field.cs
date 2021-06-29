using System;
using System.Drawing;

namespace thegame.Services
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells;

        public Palette Palette { get; set; }

        public Field(int width, int height, Palette palette)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
            Palette = palette;

            CreateField();
        }

        private void CreateField()
        {
            var random = new Random();
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Cells[x, y] = new Cell(
                        Guid.NewGuid().ToString(), 
                        new Point(x, y), 
                        Palette.Colors[random.Next(0, Palette.Colors.Length)]
                        );
                }
            }
        }

        public Cell[] ConvertInOneLine()
        {
            var cells = new Cell[Width * Height];
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    cells[x * Width + y] = Cells[x, y];
                }
            }

            return cells;
        }
    }
}