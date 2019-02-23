using System;

namespace Database
{
    public interface IGameRepository
    {
        void Insert(GameEntity game);

        void Update(GameEntity game);

        void UpdateOrInsert(GameEntity game);

        void Delete(Guid gameId);

        GameEntity GetAll();
    }
}