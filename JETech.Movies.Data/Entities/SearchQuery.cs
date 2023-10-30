namespace JETech.Movies.Data.Entities
{
    public class SearchQuery
    {
        public Guid Id { get; set; }
        public string Query { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
