using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thegame.Services
{
    public static class GameCollection
    {
        public static Dictionary<Guid, Game> Games = new ();
    }
}
