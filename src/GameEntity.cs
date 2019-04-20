using System;
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
            var gameEntity = new GameEntity(size, size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    gameEntity.objects[i, j] = new GameObject() { Type = "floor" };
                }
            }
            gameEntity.objects[2, 2] = new GameObject() {Type = "player"};
            for (int i = 0; i < size; i++)
            {
                gameEntity.objects[0, i] = new GameObject() { Type = "wall" };
                gameEntity.objects[i, 0] = new GameObject() { Type = "wall" };
                gameEntity.objects[size - 1, i] = new GameObject() { Type = "wall" };
                gameEntity.objects[i, size - 1] = new GameObject() { Type = "wall" };
            }
            gameEntity.objects[1, 1] = new GameObject() { Type = "box" };
            gameEntity.objects[2, 3] = new GameObject() { Type = "box" };
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
            return (targets[pos.X, pos.Y] == null && objects[pos.X, pos.Y] == null);
        }

        public void MovePlayer(Direction dir)
        {
            Helpers.Move(GetPlayerPosition(), dir);
        }

        public GameObject GetObject(Vec pos)
        {
            return objects[pos.X, pos.Y];
        }

        public bool AllTargetsWithBoxes()
        {
            for (var i = 0; i < targets.GetLength(0); i++)
            {
                for (var j = 0; j < targets.GetLength(1); j++)
                {
                    if (targets[i, j] == null) continue;
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

        public bool IsFinished()
        {
            return false;
        }

        public int GetScore()
        {
            return 0;
        }

        public GameObject[,] GetTargets()
        {
            return targets;
        }

        public GameObject[,] GetObjects()
        {
            return objects;
        }
    }
}