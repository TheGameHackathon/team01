using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        public int[,] Map { get; set; }

        public Game(int width, int height)
        {
            Map = new int[width, height];
            for (var i = 0; i < 2; i++)
                AddNewTile();
        }

        private void AddNewTile()
        {
            var random = new Random();
            var emptyCells = GetEmptyCells().ToList();
            var coords = emptyCells[random.Next(emptyCells.Count)];
            Map[coords.X, coords.Y] = random.NextDouble() < 0.8 ? 2 : 4;
        }

        private IEnumerable<Point> GetEmptyCells()
        {
            for (var x = 0; x < Map.GetLength(0); x++)
            {
                for (var y = 0; y < Map.GetLength(1); y++)
                {
                    if (Map[x, y] == 0)
                        yield return new Point(x, y);
                }
            }
        }
    }
}
