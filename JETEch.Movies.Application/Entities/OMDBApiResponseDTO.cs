namespace JETEch.Movies.Application.Entities
{
    public abstract class OMDBApiResponseDTO
    {
        public string Response { get; set; }

        public string? Error { get; set; }
    }
}
