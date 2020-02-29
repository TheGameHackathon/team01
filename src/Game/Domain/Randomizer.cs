using System;

namespace thegame.Game.Domain
{
    public static class Randomizer
    {
        private static Random Random = new Random();
        public static int GenerateInitCell() => Random.NextDouble() <= 0.2 ? 4 : 8;
    }
}