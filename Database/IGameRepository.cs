using System;

namespace Database
{
    public interface IGameRepository
    {
        void Insert();

        void Update(GameEntity game);

        void UpdateOrInsert(GameEntity game);

        void Delete(Guid gameId);
    }
}