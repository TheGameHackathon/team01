using System;

namespace thegame.Game.Domain
{
    public interface IGame
    {
        int[,] Field { get; }
        int Score { get; }
        int[,] ProcessAction(ActionEnum action);
    }
}