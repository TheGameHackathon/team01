using System;

namespace thegame.Game.Domain
{
    public class Randomizer
    {
        private static Random Random;
        static int GetInitCell() => Random;
    }
}