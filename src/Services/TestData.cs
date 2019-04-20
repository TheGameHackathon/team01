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
                //new CellDto("1", new Vec(2, 4), "color1", "", 0),
                //new CellDto("2", new Vec(5, 4), "color1", "", 0),
                //new CellDto("3", new Vec(3, 1), "color2", "", 20),
                //new CellDto("4", new Vec(1, 0), "color2", "", 20),
                //new CellDto("5", movingObjectPosition, "color4", "☺", 10),

                //boxes
                new CellDto("1", new Vec(3, 2), "box", "", 2),
                //walls
                new CellDto("2", new Vec(1, 1), "wall", "", 1),
                new CellDto("3", new Vec(2, 1), "wall", "", 1),
                new CellDto("4", new Vec(3, 1), "wall", "", 1),
                new CellDto("5", new Vec(4, 1), "wall", "", 1),
                new CellDto("6", new Vec(5, 1), "wall", "", 1),
                new CellDto("7", new Vec(1, 2), "wall", "", 1),
                new CellDto("8", new Vec(5, 2), "wall", "", 1),

                new CellDto("9", new Vec(1, 3), "wall", "", 1),
                new CellDto("10", new Vec(2, 3), "wall", "", 1),
                new CellDto("11", new Vec(3, 3), "wall", "", 1),
                new CellDto("12", new Vec(4, 3), "wall", "", 1),
                new CellDto("13", new Vec(5, 3), "wall", "", 1),
                //targets
                new CellDto("14", new Vec(4, 2), "target", "", 3),
                //player
                new CellDto("15", new Vec(2, 2), "player", "", 4),
                //
                //new CellDto("16", new Vec(5, 3), "floor", "", 1),
            };
            return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}