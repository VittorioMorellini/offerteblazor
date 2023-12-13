namespace OfferteWeb.Exceptions
{
    public class ForbiddenException : AuthorizeException
    {
        public ForbiddenException()
        : base(StatusCodes.Status403Forbidden)
        {
        }
    }
}
