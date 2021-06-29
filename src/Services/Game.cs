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

        
        public Game(int width = 10, int height = 10, int colorCount = 5)
        {
            field = new Field(width, height, new Palette(colorCount));
            //Score = width * height;
            Score = 0;
        }

        public void MakeStep(Color color, Point position)
        {
            var initialPoint = field.field[position.X, position.Y];
            var cellsToRepaint = GetConnectedArea(initialPoint);
            foreach (var cell in cellsToRepaint)
            {
                Score += cell.Color == color ? 0 : 1;
                cell.Color = color;
            }
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