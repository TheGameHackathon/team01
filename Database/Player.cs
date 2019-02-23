using MongoDB.Bson.Serialization.Attributes;

namespace Database
{
    public class Player
    {
        [BsonConstructor]
        public Player(string name)
        {
            Name = name;
        }

        [BsonElement]
        public string Name { get; }
    }
}