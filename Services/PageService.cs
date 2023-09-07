using BookStoreApi.Models.Testplayer;
using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStoreApi.Interfaces;

namespace BookStoreApi.Services
{
    public class PageService : IPageService
    {
        private readonly IMongoCollection<Page> _manifest;

        public PageService(
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _manifest = mongoDatabase.GetCollection<Page>(
                bookStoreDatabaseSettings.Value.PagesCollectionName);
        }

        public async Task<List<Page>> GetAsync() =>
            await _manifest.Find(_ => true).ToListAsync();

        public IEnumerable<Page> Get()
        {
            return _manifest.Find(_ => true).ToEnumerable();
        }

        //public async Task<IEnumerable<question>> GetQuestionsAsync() =>
        //    await _manifest.Database.Find(_ => true).FirstOrDefaultAsync();

        public async Task<Page> GetAsync(string id) =>
            await _manifest.Find(x => x.id == id).FirstOrDefaultAsync();


        public async Task CreateAsync(Page manifest) =>
            await _manifest.InsertOneAsync(manifest);

        //public async Task UpdateAsync(string id, Book updatedBook) =>
        //    await _manifest.ReplaceOneAsync(x => x.Id == id, updatedBook);

        //public async Task RemoveAsync(string id) =>
        //    await _manifest.DeleteOneAsync(x => x.Id == id);
    }
}
