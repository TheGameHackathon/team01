using System;
using System.Collections.Generic;
using thegame.DTO;
using thegame.Game.Domain;

namespace thegame.Repository
{
    public interface IGameRepository
    {
        Guid CreateGame(Guid userId, int fieldSize);
        IGame Find(Guid gameId);
        IGame Remove(Guid gameId);
        IEnumerable<IGame> GetAll();
    }
}