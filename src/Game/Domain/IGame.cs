using System;

namespace thegame.Game.Domain
{
    public interface IGame
    {
        void CreateGame(GameUser user);
        Field ProcessAction(Guid id, ActionEnum action);
        Field GetField(Guid id);
    }
}