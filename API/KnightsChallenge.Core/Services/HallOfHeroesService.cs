using KnightsChallenge.Core.Contexts;
using KnightsChallenge.Core.Entitys;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsChallenge.Core.Services
{
    public class HallOfHeroesService
    {
        private readonly IMongoCollection<Knight> _knightsCollection;
        public HallOfHeroesService(
            IOptions<ConnectionConfig> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _knightsCollection = mongoDatabase.GetCollection<Knight>(
                databaseSettings.Value.HallOfHeroesCollection);
        }

        public async Task<List<Knight>> GetAsync() =>
            await _knightsCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Knight newKnight) =>
            await _knightsCollection.InsertOneAsync(newKnight);
    }
}
