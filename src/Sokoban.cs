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
            var newPosition = GetPlayerPosition(dir);
            if (_gameEntity.IsEmptyCell(newPosition))
            {
                _gameEntity.MovePlayer(dir);
            }
        }

        private Vec GetPlayerPosition(Direction dir)
        {
            var currentPosition = _gameEntity.GetPlayerPosition();
            return Helpers.Move(currentPosition, dir);
        }
    }
}
