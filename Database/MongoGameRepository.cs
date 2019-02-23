using System;
using MongoDB.Driver;

namespace Database
{
    public class MongoGameRepository : IGameRepository
    {
        private readonly IMongoCollection<GameEntity> gameCollection;
        public const string CollectionName = "games";

        public MongoGameRepository(IMongoDatabase database)
        {
            gameCollection = database.GetCollection<GameEntity>(CollectionName);
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update(GameEntity game)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrInsert(GameEntity game)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public GameEntity GetAll()
        {
            throw new NotImplementedException();
        }
    }
}