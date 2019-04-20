using System;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using thegame.Models;

namespace thegame
{
    public class GameEntity
    {
        private readonly GameObject[,] _targets;
        private readonly GameObject[,] _objects;

        public GameEntity(int dim1, int dim2)
        {
            _targets = new GameObject[dim1, dim2];
            _objects = new GameObject[dim1, dim2];
        }

        public static GameEntity CreateGameEntity(int size)
        {
            var id = 0;
            var gameEntity = new GameEntity(size, size);
            gameEntity._objects[2, 2] = new GameObject(id++) {Type = "player"};
            for (int i = 0; i < size; i++)
            {
                gameEntity._objects[0, i] = new GameObject(id++) { Type = "wall" };
                gameEntity._objects[i, 0] = new GameObject(id++) { Type = "wall" };
                gameEntity._objects[size - 1, i] = new GameObject(id++) { Type = "wall" };
                gameEntity._objects[i, size - 1] = new GameObject(id++) { Type = "wall" };
            }
            gameEntity._objects[2, 1] = new GameObject(id++) { Type = "box" };
            gameEntity._objects[2, 3] = new GameObject(id++) { Type = "box" };
            //targets
            gameEntity._targets[3, 1] = new GameObject(id++) { Type = "target" };
            gameEntity._targets[3, 3] = new GameObject(id) { Type = "target" };
            return gameEntity;
        }

        public Vec GetPlayerPosition()
        {
            for (var i = 0; i < _objects.GetLength(0); i++)
            {
                for (var j = 0; j < _objects.GetLength(1); j++)
                {
                    if (_objects[i, j] == null)
                    {
                        continue;
                    }
                    if (_objects[i, j].Type == "player")
                    {
                        return new Vec(i, j);
                    }
                }
            }
            throw new Exception("player not found");
        }

        public bool IsEmptyCell(Vec pos)
        {
            return (_objects[pos.X, pos.Y] == null);
        }

        public void MovePlayer(Direction dir)
        {
            var pos = Helpers.Move(GetPlayerPosition(), dir);
            var oldPos = GetPlayerPosition();
            var player = _objects[oldPos.X, oldPos.Y];
            _objects[oldPos.X, oldPos.Y] = null;
            _objects[pos.X, pos.Y] = player;
        }

        public void MoveBox(Vec oldPos, Direction dir)
        {
            var newPos = Helpers.Move(oldPos, dir); 
            var obj = objects[oldPos.X, oldPos.Y];
            objects[oldPos.X, oldPos.Y] = null;
            objects[newPos.X, newPos.Y] = obj;
        }

        public GameObject GetObject(Vec pos)
        {
            return _objects[pos.X, pos.Y];
        }

        public bool IsFinished()
        {
            for (var i = 0; i < _targets.GetLength(0); i++)
            {
                for (var j = 0; j < _targets.GetLength(1); j++)
                {
                    if (_targets[i, j] == null) continue;
                    if (_objects[i, j] == null)
                        return false;
                    if (_objects[i, j].Type != "box")
                        return false;
                }
            }

            return true;
        }

        public int GetWidth()
        {
            return _objects.GetLength(0);
        }

        public int GetHeight()
        {
            return _objects.GetLength(1);
        }
        
        public int GetScore()
        {
            int sum = 0;
            for (int i = 0; i < _targets.GetLength(0); i++)
            {
                for (int j = 0; j < _targets.GetLength(1); j++)
                {
                    if (_targets[i, j] == null || _objects[i, j] == null) continue;
                    if (_objects[i, j].Type != "box")
                        sum++;
                }
            }

            return sum;
        }

        public GameObject[,] GetTargets()
        {
            return _targets;
        }

        public GameObject[,] GetObjects()
        {
            return _objects;
        }

        public bool IsBox(Vec pos)
        {
            return objects[pos.X, pos.Y].Type.Equals("box", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}