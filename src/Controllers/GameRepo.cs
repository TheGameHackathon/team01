using System;
using System.Collections.Generic;

namespace thegame.Controllers
{
    public class GameRepo : IGameRepo
    {
        private readonly Dictionary<Guid, GameEntity> _games = new Dictionary<Guid, GameEntity>();
        public GameEntity Get(Guid gameId)
        {
            return _games.TryGetValue(gameId, out var value) ? value : GameEntity.CreateGameEntity(5);
        }

        public void Save(GameEntity gameEntity, Guid gameId)
        {
            _games[gameId] = gameEntity;
        }
    }
}