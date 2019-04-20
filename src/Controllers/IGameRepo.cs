using System;

namespace thegame.Controllers
{
    public interface IGameRepo
    {
        GameEntity Get(Guid gameId);
        void Save(GameEntity gameEntity);
    }
}