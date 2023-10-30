using JETech.Movies.Data.Contexts;
using JETech.Movies.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JETech.Movies.Data.Repositories
{
    public class SearchQueryRepository : ISearchQueryRepository
    {
        private readonly MovieSearchContext _context;

        public SearchQueryRepository(MovieSearchContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveAsync(SearchQuery searchQuery, CancellationToken cancellationToken = default)
        {
            if (searchQuery == null)
            {
                throw new ArgumentNullException(nameof(searchQuery));
            }

            await _context.SearchQueries.AddAsync(searchQuery, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<SearchQuery>> GetRecentQueriesAsync(int count = 5, CancellationToken cancellationToken = default)
        {
            return await _context.SearchQueries.OrderByDescending(q => q.Timestamp)
                .Take(count)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
