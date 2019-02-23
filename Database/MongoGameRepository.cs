using System;
using System.Collections.Generic;
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

        public void Insert(GameEntity game)
        {
            gameCollection.InsertOne(game);
        }

        public void Update(GameEntity game)
        {
            gameCollection.ReplaceOne(g => g.Id == game.Id, game);
        }

        public void UpdateOrInsert(GameEntity game)
        {
            if (gameCollection.Find(g => g.Id == game.Id).Any())
                Update(game);
            else
                Insert(game);
        }

        public void Delete(Guid gameId)
        {
            gameCollection.DeleteOne(game => game.Id == gameId);
        }

        public IEnumerable<GameEntity> GetAll()
        {
            return gameCollection.Find(FilterDefinition<GameEntity>.Empty).ToEnumerable();
        }
    }
}