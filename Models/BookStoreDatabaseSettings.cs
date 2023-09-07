namespace BookStoreApi.Models
{
    public class BookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BooksCollectionName { get; set; } = null!;
        public string Manifest { get; set; } = null!;
        public string PagesCollectionName { get; set; } = null!;
    }
}
