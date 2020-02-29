using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Game.Domain
{
    public class Game : IGame
    {
        public Game(int[,] field)
        {
            Field = field;
            Score = 0;
        }

        public Game()
        {
            Field = Enumerable
                .Range(0, 16)
                .Select(_ => Randomizer.GenerateInitCell())
                .ToArray()
                .Create2DArray(4, 4);
        }

        public int[,] Field { get; set; }
        public int Score { get; set; }

        private static readonly Dictionary<ActionEnum, Tuple<int, int>> Shifts =
            new Dictionary<ActionEnum, Tuple<int, int>>
            {
                {ActionEnum.down, Tuple.Create(1, 0)},
                {ActionEnum.up, Tuple.Create(-1, 0)},
                {ActionEnum.left, Tuple.Create(0, -1)},
                {ActionEnum.right, Tuple.Create(0, 1)},
            };

        public int[,] ProcessAction(ActionEnum action)
        {
            var (iShift, jShift) = Shifts[action];
            var heigth = Field.GetLength(0);
            var widht = Field.GetLength(1);

            var (iStart, iEnd) = (0, heigth);
            var (jStart, jEnd) = (0, widht);

            if (action == ActionEnum.up)
                (iStart, iEnd) = (iEnd, iStart);
            if (action == ActionEnum.left)
                (jStart, jEnd) = (jEnd, jStart);

            for (var i = iStart; i < iEnd; ++i)
            for (var j = jStart; j < jEnd; ++j)
            {
                var iLast = i;
                var jLast = j;
                var iNext = i + iShift;
                var jNext = j + jShift;
                while (Field.IsInBorders(iNext, jNext) && Field[iNext, jNext] == 0)
                {
                    Field.Swap(iLast, jLast, iNext, jNext);
                    (iLast, jLast) = (iNext, jNext);
                    (iNext, jNext) = (iNext + iShift, jNext + jNext);
                }

                if (Field.IsInBorders(iNext, jNext) && Field[iLast, jLast] == Field[iNext, jNext])
                {
                    Field[iLast, jLast] = 0;
                    Field[iNext, jNext] *= 2;
                }
            }

            return Field;
        }
    }
}