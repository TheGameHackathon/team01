using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Game.Domain
{
    public class Game : IGame
    {
        private readonly Random Random;

        public Game(int[,] field)
        {
            Field = field;
            ActionsAllowed = new bool[field.GetLength(0), field.GetLength(1)];
            Random = new Random();
            Score = 0;
            ZeroCells = field.As1DArray().Count(c => c == 0);
        }

        public Game() : this(new int[4, 4])
        {
        }

        public int[,] Field { get; set; }
        private bool[,] ActionsAllowed { get; set; }
        public int Score { get; set; }

        private int ZeroCells { get; set; }
        public bool IsOver => ZeroCells <= 0;

        private static readonly Dictionary<ActionEnum, Tuple<int, int>> Shifts =
            new Dictionary<ActionEnum, Tuple<int, int>>
            {
                {ActionEnum.down, Tuple.Create(1, 0)},
                {ActionEnum.up, Tuple.Create(-1, 0)},
                {ActionEnum.left, Tuple.Create(0, -1)},
                {ActionEnum.right, Tuple.Create(0, 1)},
            };

        private void AddRandomCell()
        {
            var height = Field.GetLength(0);
            var width = Field.GetLength(1);
            var zerosCount = Field.As1DArray().Count(c => c == 0);
            if (zerosCount == 0)
                return;
            var processedZeros = 0;
            for (var i = 0; i < height; ++i)
            for (var j = 0; j < width; ++j)
            {
                if (Field[i, j] != 0)
                    continue;
                processedZeros++;
                if (Random.NextDouble() > 1.0 / zerosCount && processedZeros != zerosCount)
                    continue;
                Field[i, j] = 2;
                if (Random.NextDouble() < 0.2)
                    Field[i, j] = 4;
                return;
            }
        }

        public int[,] ProcessAction(ActionEnum action)
        {
            if (IsOver)
                return Field;
            
            var (iShift, jShift) = Shifts[action];
            var heigth = Field.GetLength(0);
            var widht = Field.GetLength(1);

            ActionsAllowed.FillWith(true);

            var (iStart, iEnd, iStep) = (-1, heigth, 1);
            var (jStart, jEnd, jStep) = (-1, widht, 1);

            if (action == ActionEnum.down)
                (iStart, iEnd, iStep) = (iEnd, iStart, -1);
            if (action == ActionEnum.right)
                (jStart, jEnd, jStep) = (jEnd, jStart, -1);

            for (var i = iStart; i != iEnd; i += iStep)
            for (var j = jStart; j != jEnd; j += jStep)
            {
                var iLast = i;
                var jLast = j;
                var iNext = i + iShift;
                var jNext = j + jShift;
                while (Field.IsInBorders(iNext, jNext)
                       && Field.IsInBorders(iLast, jLast)
                       && Field[iNext, jNext] == 0
                       && Field[iLast, jLast] != 0)
                {
                    Field.Swap(iLast, jLast, iNext, jNext);
                    (iLast, jLast) = (iNext, jNext);
                    (iNext, jNext) = (iNext + iShift, jNext + jNext);
                }

                if (Field.IsInBorders(iNext, jNext)
                    && Field.IsInBorders(iLast, jLast)
                    && ActionsAllowed[iNext, jNext]
                    && Field[iLast, jLast] == Field[iNext, jNext])
                {
                    Field[iLast, jLast] = 0;
                    Field[iNext, jNext] *= 2;
                    ZeroCells++;
                    Score = Math.Max(Field[iNext, jNext], Score);
                    ActionsAllowed[iNext, jNext] = false;
                }
            }

            AddRandomCell();
            ZeroCells--;

            return Field;
        }
    }
}