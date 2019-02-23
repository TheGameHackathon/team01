﻿using System;
using MongoDB.Driver;

namespace Database
{
    public static class GameMongoDatabase
    {
        public static IMongoDatabase Create()
        {
            var mongoConnectionString = Environment.GetEnvironmentVariable("PROJECT5100_MONGO_CONNECTION_STRING")
                                        ?? "mongodb://localhost:27017";
            var mongoClient = new MongoClient(mongoConnectionString);
            return mongoClient.GetDatabase("2048-games");
        }
    }
}
