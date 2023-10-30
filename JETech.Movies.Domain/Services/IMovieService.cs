using JETech.Movies.Domain.Entities;

namespace JETech.Movies.Domain.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> SearchAsync(string title, CancellationToken cancellationToken = default);
        Task<Movie> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}