using System.ComponentModel.DataAnnotations;
using JETech.Movies.Application.Services;
using JETech.Movies.Data.Contexts;
using JETech.Movies.Data.Repositories;
using JETech.Movies.Domain.Services;
using JETEch.Movies.Application.Infrastructure;
using JETEch.Movies.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<MovieSearchContext>(options =>
    options.UseInMemoryDatabase("MovieSearchDB"));

builder.Services.Configure<OMDBSettings>(builder.Configuration.GetSection("OMDBSettings"));

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ISearchQueryService, SearchQueryService>();

builder.Services.AddScoped<ISearchQueryRepository, SearchQueryRepository>();

builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/movies/search", async (IMovieService movieService, [Required] string title) =>
{
    var movies = await movieService.SearchAsync(title);
    return Results.Ok(movies);
});

app.MapGet("/api/movies/{id}", async (IMovieService movieService, [Required] string id) =>
{
    var movie = await movieService.GetByIdAsync(id);
    if (movie == null)
    {
        return Results.NotFound("Movie was not found");
    }

    return Results.Ok(movie);
});

app.MapGet("/api/movies/recent-searches", async (ISearchQueryService searchQueryService) =>
{
    var recentSearches = await searchQueryService.GetRecentSearchQueriesAsync();
    return Results.Ok(recentSearches);
});

app.Run();
