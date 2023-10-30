using JETech.Movies.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JETech.Movies.Data.Contexts
{
    public class MovieSearchContext : DbContext
    {
        public DbSet<SearchQuery> SearchQueries { get; set; }

        public MovieSearchContext(DbContextOptions<MovieSearchContext> options)
            : base(options)
        {
        }
    }
}
