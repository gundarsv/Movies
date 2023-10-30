using System.Text.Json.Serialization;
using JETEch.Movies.Application.Entities;

namespace JETech.Movies.Application.Entities
{
    public class MovieDetailDTO : OMDBApiResponseDTO
    {
        [JsonPropertyName("imdbID")]
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public string Released { get; set; }
    }
}
