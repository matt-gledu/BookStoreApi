using BookStoreApi.Models.Testplayer;

namespace BookStoreApi.Interfaces
{
    public interface IPageService
    {
        Task CreateAsync(Page manifest);
        IEnumerable<Page> Get();
        Task<List<Page>> GetAsync();
        Task<Page> GetAsync(string id);
        //Task<Page> GetByDocumentIdAsync(string id);
    }
}
