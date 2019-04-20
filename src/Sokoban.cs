using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame
{
    public class Sokoban
    {
        private readonly GameEntity _gameEntity;

        public Sokoban(GameEntity gameEntity)
        {
            _gameEntity = gameEntity;
        }

        public void Move(Direction dir)
        {
            var newPosition = GetNewPlayerPosition(dir);

            if (_gameEntity.IsEmptyCell(newPosition))
            {
                _gameEntity.MovePlayer(dir);
                return;
            }

            //check box
            if (!_gameEntity.IsBox(newPosition))
            {
                return;
            }

            var boxPosition = newPosition;

            var newBoxPosition = Helpers.Move(boxPosition, dir);

            if (_gameEntity.IsEmptyCell(newBoxPosition))
            {
                _gameEntity.MovePlayer(dir);
                _gameEntity.MoveBox(boxPosition, dir);
                return;
            }

             
        }
         

        private bool MoveObject(Direction dir, Vec newPosition)
        {
            if (!_gameEntity.IsEmptyCell(newPosition)) return false;
            _gameEntity.MovePlayer(dir);
            return true;

        }

        private Vec GetNewPlayerPosition(Direction dir)
        {
            var currentPosition = _gameEntity.GetPlayerPosition();
            return Helpers.Move(currentPosition, dir);
        }
    }
}
