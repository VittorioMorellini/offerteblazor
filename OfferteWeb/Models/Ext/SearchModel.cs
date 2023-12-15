namespace OfferteWeb.Models
{
    public class BaseSearchModel
    {
        public long? Id { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? IncludeDeleted { get; set; }
        public int? Limit { get; set; }

    }

}