using MudBlazor;

namespace OfferteWeb.Models
{
    public class PagerModel
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string OrderBy { get; set; }
        public SortDirection Direction { get; set; }
        public bool Ignore { get; set; }
    }

}
