namespace JETech.Movies.Domain.Services
{
    public interface ISearchQueryService
    {
        Task<IEnumerable<string>> GetRecentSearchQueriesAsync(CancellationToken cancellationToken = default);
        Task SaveSearchQuery(string title, CancellationToken cancellationToken = default);
    }
}
