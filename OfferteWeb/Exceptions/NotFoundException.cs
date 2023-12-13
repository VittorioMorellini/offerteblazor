namespace OfferteWeb.Exceptions
{
    public class NotFoundException : AuthorizeException
    {
        public NotFoundException()
        : base(StatusCodes.Status404NotFound)
        {
        }
    }
}
