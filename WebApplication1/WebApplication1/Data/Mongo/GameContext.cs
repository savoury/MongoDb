using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Mongo.Domain;

namespace WebApplication1.Data.Mongo
{
    public class GameContext : IGameContext
    {
        private readonly IMongoDatabase _db;
        public GameContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
            _db.RunCommandAsync((Command<BsonDocument>)"{ping:1}")
        .Wait();
        }
        public IMongoCollection<Game> Games => _db.GetCollection<Game>("Games");
    }

    public interface IGameContext
    {
        IMongoCollection<Game> Games { get; }
    }
}

