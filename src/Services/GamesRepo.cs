using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public class GamesRepo
    {
        public GameDto Field { get; set; }

        public GamesRepo()
        {
            Field = TestData.AGameDto(new Vec(1, 1));
        }
    }
}