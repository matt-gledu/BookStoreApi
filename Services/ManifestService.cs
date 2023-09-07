using BookStoreApi.Models;
using BookStoreApi.Models.Testplayer;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace BookStoreApi.Services
{
    public class ManifestService
    {
        private readonly IMongoCollection<Manifest> _manifest;

        public ManifestService(
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _manifest = mongoDatabase.GetCollection<Manifest>(
                bookStoreDatabaseSettings.Value.Manifest);
        }

        public async Task<Manifest> GetAsync() =>
            await _manifest.Find(_ => true).FirstOrDefaultAsync();

        //public async Task<IEnumerable<question>> GetQuestionsAsync() =>
        //    await _manifest.Database.Find(_ => true).FirstOrDefaultAsync();

        public async Task<Manifest?> GetAsync(string id) =>
            await _manifest.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Manifest manifest) =>
            await _manifest.InsertOneAsync(manifest);

        //public async Task UpdateAsync(string id, Book updatedBook) =>
        //    await _manifest.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _manifest.DeleteOneAsync(x => x.Id == id);
    }
}
