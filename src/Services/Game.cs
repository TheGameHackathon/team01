using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace thegame.Services
{
    public class Game
    {
        public Guid Id { get; set; }
        public Field field { get; set; }
        public int Score { get; set; }

        
        public Game(LevelDifficult difficult)
        {
            switch (difficult)
            {
                case LevelDifficult.LowLevel:
                    field = new Field(10, 10, new Palette(4));
                    break;
                case LevelDifficult.MiddleLevel:
                    field = new Field(20, 20, new Palette(8));
                    break;
                case LevelDifficult.HighLevel:
                    field = new Field(30, 30, new Palette(16));
                    break;
            }
            Score = 0;
        }

        public void MakeStep(Color color, Point position)
        {
            var initialPoint = field.field[position.X, position.Y];
            var cellsToRepaint = GetConnectedArea(initialPoint);
            var backCellsToRepaintCount = cellsToRepaint.Count();
            var backScore = Score;

            foreach (var cell in cellsToRepaint)
            {
                Score += cell.Color == color ? 0 : 1;
                cell.Color = color;
            }

            if (backCellsToRepaintCount == GetConnectedArea(initialPoint).Count())
            {
                Score = backScore;
            }
        }

        public void MakeAIStep()
        {
            var initialColor = field.field[0, 0].Color;
            var maxNeighbours = 0;
            Color targetColor = field.Palette.colors[0];
            var backup = new Color[field.Width, field.Height];
            var backupScore = Score;
            foreach (var cell in field.ConvertInOneLine())
            {
                backup[cell.Pos.X, cell.Pos.Y] = cell.Color;
            }
            foreach (var color in field.Palette.colors)
            {
                MakeStep(color, new Point(0,0));
                var cellsToRepaint = GetConnectedArea(field.field[0,0]);
                if (maxNeighbours < cellsToRepaint.Length)
                {
                    maxNeighbours = cellsToRepaint.Length;
                    targetColor = color;
                }

                foreach (var cell in field.ConvertInOneLine())
                {
                    cell.Color = backup[cell.Pos.X, cell.Pos.Y];
                }
            }

            Score = backupScore;
            MakeStep(targetColor, new Point(0,0));
        }

        public bool Finished(Color color)
        {
            return field.ConvertInOneLine().All(c => c.Color == color);
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
                var neighbours = GetNeighbours(current);
                foreach (var neighbour in neighbours)
                {
                    if (neighbour.Color.Equals(color) && !visitedPoints.Contains(neighbour))
                    {
                        connectedArea.Add(neighbour);
                        stack.Push(neighbour);
                    }
                }
            }

            return connectedArea.ToArray();
        }

        private Cell[] GetNeighbours(Cell cell)
        {
            var points = new List<Cell>();
            if (cell.Pos.X > 0)
                points.Add(field.field[cell.Pos.X - 1, cell.Pos.Y]);
            if (cell.Pos.X < field.Width - 1)
                points.Add(field.field[cell.Pos.X + 1, cell.Pos.Y]);
            if (cell.Pos.Y > 0)
                points.Add(field.field[cell.Pos.X, cell.Pos.Y - 1]);
            if (cell.Pos.Y < field.Height - 1)
                points.Add(field.field[cell.Pos.X, cell.Pos.Y + 1]);
            return points.ToArray();
        }
    }
}