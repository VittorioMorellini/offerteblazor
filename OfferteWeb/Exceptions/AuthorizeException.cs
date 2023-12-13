namespace OfferteWeb.Exceptions
{
    public class AuthorizeException : Exception
    {
        public int StatusCode { get; }

        public AuthorizeException(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
