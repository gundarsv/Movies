using JETech.Movies.Data.Entities;

namespace JETech.Movies.Data.Repositories
{
    public interface ISearchQueryRepository
    {
        Task<IEnumerable<SearchQuery>> GetRecentQueriesAsync(int count = 5, CancellationToken cancellationToken = default);
        Task SaveAsync(SearchQuery searchQuery, CancellationToken cancellationToken = default);
    }
}