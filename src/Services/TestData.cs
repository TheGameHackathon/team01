using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 10;
            var height = 8;
            var testCells = new[]
            {
                new CellDto("1", new Vec(2, 4), "color1", "", 0),
                new CellDto("2", new Vec(5, 4), "color1", "", 0),
                new CellDto("3", new Vec(3, 1), "color2", "", 20),
                new CellDto("4", new Vec(1, 0), "color2", "", 20),
                new CellDto("5", movingObjectPosition, "color4", "☺", 10),
                new CellDto("6", new Vec(9, 7), "color0", "", 20),
            };
            return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}