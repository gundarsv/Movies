namespace JETech.Movies.Application.Exceptions
{
    public class MovieServiceException : Exception
    {
        public MovieServiceException()
        {
        }

        public MovieServiceException(string message)
            : base(message)
        {
        }

        public MovieServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
