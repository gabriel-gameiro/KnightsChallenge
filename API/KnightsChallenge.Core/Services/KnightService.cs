using KnightsChallenge.Core.Contexts;
using KnightsChallenge.Core.Entitys;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsChallenge.Core.Services
{
    public class KnightService
    {
        // Service para manipulacao da KnightsCollection
        private readonly IMongoCollection<Knight> _knightsCollection;
        public KnightService(
            IOptions<ConnectionConfig> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _knightsCollection = mongoDatabase.GetCollection<Knight>(
                databaseSettings.Value.KnightsCollection);
        }

        // CRUD
        public async Task<List<Knight>> GetAsync() =>
            await _knightsCollection.Find(_ => true).ToListAsync();

        public async Task<Knight?> GetAsync(string id) =>
            await _knightsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Knight newKnight) =>
            await _knightsCollection.InsertOneAsync(newKnight);

        public async Task UpdateAsync(string id, Knight updatedKnight) =>
            await _knightsCollection.ReplaceOneAsync(x => x.Id == id, updatedKnight);

        public async Task RemoveAsync(string id) =>
            await _knightsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
