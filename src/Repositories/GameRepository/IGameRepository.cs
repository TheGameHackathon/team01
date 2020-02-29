using System;
using System.Collections.Generic;
using thegame.Game.Domain;

namespace thegame.Repository
{
    public interface IGameRepository
    {
        Guid CreateGame(Guid userId, int fieldSize);
        IGame Find(Guid gameId);
        bool IsUserPlayThisGame(Guid userId, Guid gameId);
        bool IsUserHaveActiveGame(Guid userId, out Guid gameId);
        void Remove(Guid gameId);
        IEnumerable<IGame> GetAll();
    }
}