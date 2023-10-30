using JETech.Movies.Data.Entities;
using JETech.Movies.Data.Repositories;
using JETech.Movies.Domain.Services;
using Microsoft.Extensions.Logging;

namespace JETEch.Movies.Application.Services
{
    public class SearchQueryService : ISearchQueryService
    {
        private readonly ISearchQueryRepository _searchQueryRepository;
        private readonly ILogger<SearchQueryService> _logger;

        public SearchQueryService(ISearchQueryRepository searchQueryRepository, ILogger<SearchQueryService> logger)
        {
            _searchQueryRepository = searchQueryRepository ?? throw new ArgumentNullException(nameof(searchQueryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task SaveSearchQuery(string title, CancellationToken cancellationToken = default)
        {
            try
            {
                await _searchQueryRepository.SaveAsync(new SearchQuery { Query = title, Id = Guid.NewGuid(), Timestamp = DateTime.Now }, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching recent search queries. Exception: {message}", ex.Message);
            }
        }

        public async Task<IEnumerable<string>> GetRecentSearchQueriesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var recentSearchQueries = await _searchQueryRepository.GetRecentQueriesAsync(cancellationToken: cancellationToken);
                return recentSearchQueries.Select(x => x.Query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching recent search queries. Exception: {message}", ex.Message);
                return new List<string>();
            }
        }
    }
}
