using System;
using System.Collections.Generic;
using thegame.Game.Domain;

namespace thegame.Repository
{
    public class GameRepository : IGameRepository
    {
        private Dictionary<Guid, IGame> _games = new Dictionary<Guid, IGame>();
        private Dictionary<Guid, Guid> _userAssociations = new Dictionary<Guid, Guid>();
        
        public Guid CreateGame(Guid userId, int fieldSize)
        {
            if(_userAssociations.ContainsKey(userId))
                throw new ArgumentException("HOW DO YOU DO THAT SHIT IN CREATE GAME?!");
            
            var game = new Game.Domain.Game(new int[fieldSize,fieldSize]);
            var gameId = new Guid();
            
            _games.Add(gameId, game);
            _userAssociations.Add(userId, gameId);
            return gameId;
        }

        public IGame Find(Guid gameId)
        {
            return _games.ContainsKey(gameId) ? _games[gameId] : null;
        }

        public bool IsUserPlayThisGame(Guid userId, Guid gameId)
        {
            return _userAssociations.ContainsKey(userId)
                   && _userAssociations[userId].Equals(gameId);
        }

        public bool IsUserHaveActiveGame(Guid userId, out Guid gameId)
        {
            if (_userAssociations.ContainsKey(userId))
            {
                gameId = _userAssociations[userId];
                return true;
            }
            
            gameId = Guid.Empty;
            return false;
        }

        public void Remove(Guid gameId)
        {
            if (_games.ContainsKey(gameId))
                _games.Remove(gameId);
        }

        public IEnumerable<IGame> GetAll()
        {
            return _games.Values;
        }
    }
}