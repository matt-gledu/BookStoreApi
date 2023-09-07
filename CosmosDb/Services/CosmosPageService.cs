using BookStoreApi.Interfaces;
using BookStoreApi.Models.Testplayer;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;

namespace BookStoreApi.CosmosDb.Services
{
    public class CosmosPageService : IPageService
    {
        private readonly CosmosClient _client;

        public CosmosPageService(IOptions<ManifestStoreDatabaseSettings> manifestStoreDatabaseSettings)
        {
            Console.WriteLine(manifestStoreDatabaseSettings.Value.ConnectionString);

            _client = new CosmosClient(
                connectionString: manifestStoreDatabaseSettings.Value.ConnectionString
            );
        }

        private Container container
        {
            get => _client.GetDatabase("Authoring").GetContainer("Pages");
        }

        public Task CreateAsync(Page manifest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Page> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Page> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Page> GetByDocumentIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Page>> GetAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c "
                //+ "WHERE c.myProperty = @myValue"
                )
                .WithParameter("@myValue", "someValue");

            var iterator = container.GetItemQueryIterator<Page>(query);

            List<Page> results = new();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                foreach (Page item in response)
                {
                    results.Add(item);
                }
            }

            return results;
        }
        public async Task<IEnumerable<Page>> GetAsync0()
        {
            var queryable = container.GetItemLinqQueryable<Page>();

            using FeedIterator<Page> feed = queryable
                //.Where(p => p. < 2000m)
                .OrderByDescending(p => p.id)
                .ToFeedIterator();

            List<Page> results = new();

            while (feed.HasMoreResults)
            {
                var response = await feed.ReadNextAsync();
                foreach (Page item in response)
                {
                    results.Add(item);
                }
            }

            return results;
        }
    }
}
