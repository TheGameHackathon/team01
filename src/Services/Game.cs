using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace thegame.Services
{
    public class Game
    {
        public Guid Id { get; set; }
        public Field Field { get; set; }
        public int Score { get; set; }

        
        public Game(LevelDifficult difficult)
        {
            Field = difficult switch
            {
                LevelDifficult.LowLevel => new Field(10, 10, new Palette(4)),
                LevelDifficult.MiddleLevel => new Field(20, 20, new Palette(8)),
                LevelDifficult.HighLevel => new Field(30, 30, new Palette(16)),
                _ => Field
            };
            Score = 0;
        }

        public void MakeStep(Color color, Point position)
        {
            var initialPoint = Field.Cells[position.X, position.Y];
            var cellsToRepaint = GetConnectedArea(initialPoint);
            var backCellsToRepaintCount = cellsToRepaint.Length;
            var backScore = Score;

            foreach (var cell in cellsToRepaint)
            {
                Score += cell.Color == color ? 0 : 1;
                cell.Color = color;
            }

            if (backCellsToRepaintCount == GetConnectedArea(initialPoint).Length)
            {
                Score = backScore;
            }
        }

        public void MakeAIStep()
        {
            var maxNeighbors = 0;
            var targetColor = Field.Palette.Colors[0];
            var backup = new Color[Field.Width, Field.Height];
            var backupScore = Score;
            foreach (var cell in Field.ConvertInOneLine())
            {
                backup[cell.Pos.X, cell.Pos.Y] = cell.Color;
            }
            foreach (var color in Field.Palette.Colors)
            {
                MakeStep(color, new Point(0,0));
                var cellsToRepaint = GetConnectedArea(Field.Cells[0,0]);
                if (maxNeighbors < cellsToRepaint.Length)
                {
                    maxNeighbors = cellsToRepaint.Length;
                    targetColor = color;
                }

                foreach (var cell in Field.ConvertInOneLine())
                {
                    cell.Color = backup[cell.Pos.X, cell.Pos.Y];
                }
            }

            Score = backupScore;
            MakeStep(targetColor, new Point(0,0));
        }

        public bool Finished(Color color)
        {
            return Field.ConvertInOneLine().All(c => c.Color == color);
        }

        public Cell[] GetConnectedArea(Cell initialPoint)
        {
            var connectedArea = new List<Cell>() {initialPoint};
            var stack = new Stack<Cell>();
            stack.Push(initialPoint);
            var color = initialPoint.Color;
            var visitedPoints = new HashSet<Cell>();
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                visitedPoints.Add(current);
                var neighbors = GetNeighbors(current);
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.Color.Equals(color) && !visitedPoints.Contains(neighbor))
                    {
                        connectedArea.Add(neighbor);
                        stack.Push(neighbor);
                    }
                }
            }

            return connectedArea.ToArray();
        }

        private Cell[] GetNeighbors(Cell cell)
        {
            var points = new List<Cell>();
            if (cell.Pos.X > 0)
                points.Add(Field.Cells[cell.Pos.X - 1, cell.Pos.Y]);
            if (cell.Pos.X < Field.Width - 1)
                points.Add(Field.Cells[cell.Pos.X + 1, cell.Pos.Y]);
            if (cell.Pos.Y > 0)
                points.Add(Field.Cells[cell.Pos.X, cell.Pos.Y - 1]);
            if (cell.Pos.Y < Field.Height - 1)
                points.Add(Field.Cells[cell.Pos.X, cell.Pos.Y + 1]);
            return points.ToArray();
        }
    }
}