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
            ActionsAllowed = new bool[field.GetLength(0),field.GetLength(1)];
            Score = 0;
        }

        public Game()
        {
            Field = Enumerable
                .Range(0, 16)
                .Select(_ => Randomizer.GenerateInitCell())
                .ToArray()
                .Create2DArray(4, 4);
            
            ActionsAllowed = new bool[4, 4];
        }

        public int[,] Field { get; set; }
        private bool[,] ActionsAllowed { get; set; }
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

                    ActionsAllowed[iNext, jNext] = false;
                }
            }

            return Field;
        }
    }
}