using System.Drawing;

namespace thegame.Services
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] field;

        public Field(int width, int height, Color[] colors)
        {
            Width = width;
            Height = height;
            field = new Cell[width, height];
        }

        private void CreateField()
        {
               
        }
    }
}