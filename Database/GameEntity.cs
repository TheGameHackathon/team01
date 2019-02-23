using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Database
{
    public class GameEntity
    {
        [BsonConstructor]
        public GameEntity(Player player)
        {
            Player = player;
        }

        public int Score { get; set; } = 0;

        [BsonElement]
        public Player Player { get; }

        public Guid Id
        {
            get;
            // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local For MongoDB
            private set;
        }
    }
}