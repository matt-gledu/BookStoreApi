namespace BookStoreApi.CosmosDb
{
    public class ManifestStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;
        public string Manifest { get; set; } = null!;
        public string PagesCollectionName { get; set; } = null!;
    }
}
