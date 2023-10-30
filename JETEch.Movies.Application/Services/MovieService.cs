using System.Text.Json;
using JETech.Movies.Application.Entities;
using JETech.Movies.Application.Exceptions;
using JETech.Movies.Domain.Entities;
using JETech.Movies.Domain.Services;
using JETEch.Movies.Application.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JETech.Movies.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MovieService> _logger;
        private readonly ISearchQueryService _searchQueryService;

        private readonly string _apiKey;
        private readonly string _baseUrl;

        public MovieService(HttpClient httpClient, ILogger<MovieService> logger, ISearchQueryService searchQueryService, IOptions<OMDBSettings> settings)
        {
            _httpClient = httpClient;
            _logger = logger;
            _searchQueryService = searchQueryService;
            _apiKey = settings.Value.ApiKey;
            _baseUrl = settings.Value.BaseUrl;
        }

        public async Task<IEnumerable<Movie>> SearchAsync(string title, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}?s={title}&apikey={_apiKey}", cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Failed to fetch movies for query: {title}. Response Code: {statusCode}", title, response.StatusCode);
                    return new List<Movie>();
                }

                var content = await response.Content.ReadAsStreamAsync(cancellationToken);
                var searchResponse = await JsonSerializer.DeserializeAsync<SearchResponseDTO>(content, cancellationToken: cancellationToken);

                await _searchQueryService.SaveSearchQuery(title, cancellationToken);

                if (searchResponse is null)
                {
                    throw new MovieServiceException("Search response is null");
                }

                if (searchResponse.Response == false.ToString())
                {
                    throw new MovieServiceException($"Search response is false. Error: {searchResponse.Error}");
                }

                return searchResponse.Search
                    .Select(x => new Movie
                    {
                        ImdbID = x.ImdbID,
                        Poster = x.Poster,
                        Title = x.Title,
                        Type = x.Type,
                        Year = x.Year
                    }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching movies for query: {title}. Exception: {message}", title, ex.Message);
                return new List<Movie>();
            }
        }

        public async Task<Movie> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}?i={id}&apikey={_apiKey}", cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Failed to fetch movie by id: {id}. Response Code: {statusCode}", id, response.StatusCode);
                    return null;
                }

                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                var movie = JsonSerializer.Deserialize<MovieDetailDTO>(stream);

                if (movie is null)
                {
                    throw new MovieServiceException("Search response is null");
                }

                if (movie.Response == false.ToString())
                {
                    throw new MovieServiceException($"Search response is false. Error: {movie.Error}");
                }

                return new MovieDetailed
                {
                    ImdbID = movie.ImdbID,
                    Released = movie.Released,
                    Year = movie.Year,
                    Poster = movie.Poster,
                    Title = movie.Title,
                    Type = movie.Type
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching movie by Id: {id}. Exception: {message}", id, ex.Message);
                return null;
            }
        }
    }
}