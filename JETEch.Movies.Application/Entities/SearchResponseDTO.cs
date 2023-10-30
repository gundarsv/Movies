using JETEch.Movies.Application.Entities;

namespace JETech.Movies.Application.Entities
{
    public class SearchResponseDTO : OMDBApiResponseDTO
    {
        public List<MovieDTO> Search { get; set; }
    }
}
