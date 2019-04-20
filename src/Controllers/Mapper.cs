using System;
using System.Collections.Generic;
using System.Linq;
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

        private static CellDto[] GetCells(GameEntity gameEntity)
        {
            var id = 0;
            var cells = new List<CellDto>();
            ProcessObjects(cells, gameEntity.GetObjects(), 0, ref id);
            ProcessObjects(cells, gameEntity.GetTargets(), 1, ref id);
            return cells.ToArray();
        }

        private static void ProcessObjects(ICollection<CellDto> cells, GameObject[,] objects, int zIndex, ref int id)
        {
            var width = objects.GetLength(1);
            for (int i = 0; i < objects.GetLength(0); i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells.Add(new CellDto(id:id++.ToString(), pos: new Vec(j,i), type: objects[i,j].Type, content: "", zIndex: zIndex));
                }
            }
        }

    }
}