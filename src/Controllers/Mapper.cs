using System;
using thegame.Models;

namespace thegame.Controllers
{
    public class Mapper
    {
        public GameDto Map(GameEntity gameEntity, Guid gameId)
        {
            return new GameDto(GetCells(gameEntity), 
                monitorKeyboard: true, 
                monitorMouseClicks: false, 
                width:gameEntity.GetWidth(),
                height: gameEntity.GetHeight(),
                id: gameId,
                isFinished:gameEntity.IsFinished(), 
                score:gameEntity.GetScore());
        }

        private CellDto[] GetCells(GameEntity gameEntity)
        {
            gameEntity.GetTargets();

        }
    }
}