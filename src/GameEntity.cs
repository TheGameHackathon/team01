using System;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using thegame.Models;

namespace thegame
{
    public class GameEntity
    {
        private GameObject[,] targets;
        private GameObject[,] objects;

        public GameEntity(int dim1, int dim2)
        {
            targets = new GameObject[dim1, dim2];
            objects = new GameObject[dim1, dim2];
        }

        public static GameEntity CreateGameEntity(int size)
        {
            var id = 0;
            var gameEntity = new GameEntity(size, size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //gameEntity.objects[i, j] = new GameObject() { Type = "floor" };
                }
            }
            gameEntity.objects[2, 2] = new GameObject(id++) {Type = "player"};
            for (int i = 0; i < size; i++)
            {
                gameEntity.objects[0, i] = new GameObject(id++) { Type = "wall" };
                gameEntity.objects[i, 0] = new GameObject(id++) { Type = "wall" };
                gameEntity.objects[size - 1, i] = new GameObject(id++) { Type = "wall" };
                gameEntity.objects[i, size - 1] = new GameObject(id++) { Type = "wall" };
            }
            gameEntity.objects[2, 1] = new GameObject(id++) { Type = "box" };
            gameEntity.objects[2, 3] = new GameObject(id++) { Type = "box" };
            //
            gameEntity.targets[3, 1] = new GameObject(id++) { Type = "target" };
            gameEntity.targets[3, 3] = new GameObject(id++) { Type = "target" };
            return gameEntity;
        }

        public Vec GetPlayerPosition()
        {
            for (int i = 0; i < objects.GetLength(0); i++)
            {
                for (int j = 0; j < objects.GetLength(1); j++)
                {
                    if (objects[i, j] == null)
                    {
                        continue;
                    }
                    if (objects[i, j].Type == "player")
                    {
                        return new Vec(i, j);
                    }
                }
            }
            throw new Exception("player not found");
        }

        public bool IsEmptyCell(Vec pos)
        {
            return (objects[pos.X, pos.Y] == null );
        }

        public void MovePlayer(Direction dir)
        {
            var pos = Helpers.Move(GetPlayerPosition(), dir);
            var oldPos = GetPlayerPosition();
            var player = objects[oldPos.X, oldPos.Y];
            objects[oldPos.X, oldPos.Y] = null;
            objects[pos.X, pos.Y] = player;
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
            return objects[pos.X, pos.Y];
        }

        public bool IsFinished()
        {
            for (var i = 0; i < targets.GetLength(0); i++)
            {
                for (var j = 0; j < targets.GetLength(1); j++)
                {
                    if (targets[i, j] == null) continue;
                    if (objects[i, j] == null)
                        return false;
                    if (objects[i, j].Type != "box")
                        return false;
                }
            }

            return true;
        }

        public int GetWidth()
        {
            return objects.GetLength(0);
        }

        public int GetHeight()
        {
            return objects.GetLength(1);
        }
        
        public int GetScore()
        {
            int sum = 0;
            for (int i = 0; i < targets.GetLength(0); i++)
            {
                for (int j = 0; j < targets.GetLength(1); j++)
                {
                    if (targets[i, j] == null || objects[i, j] == null) continue;
                    if (objects[i, j].Type != "box")
                        sum++;
                }
            }

            return sum;
        }

        public GameObject[,] GetTargets()
        {
            return targets;
        }

        public GameObject[,] GetObjects()
        {
            return objects;
        }

        public bool IsBox(Vec pos)
        {
            return objects[pos.X, pos.Y].Type.Equals("box", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}