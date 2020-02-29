﻿using System;

namespace thegame.Game.Domain
{
    public class Game : IGame
    {
        public Game(int[,] field)
        {
            Field = field;
            Score = 0;
        }

        public int[,] Field { get; set; }
        public int Score { get; set; }
        public int[,] ProcessAction(ActionEnum action)
        {
            throw new NotImplementedException();
        }
    }
}