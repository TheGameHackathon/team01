using System.Drawing;

namespace thegame.Services
{
    public class Cell
    {
        public Cell(string id, Point pos, Color color)
        {
            Id = id;
            Pos = pos;
            Color = color;
        }

        public string Id { get; }
        public Point Pos { get; set; }
        public Color Color { get; set; }
    }
}