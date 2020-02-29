using System;
using System.Collections.Generic;
using thegame.DTO;
using thegame.Game.Domain;

namespace thegame.Repository
{
    public class GameRepository : IGameRepository
    {
        public Guid CreateGame(Guid userId, int fieldSize)
        {
            throw new NotImplementedException();
        }

        public IGame Find(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public IGame Remove(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGame> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}