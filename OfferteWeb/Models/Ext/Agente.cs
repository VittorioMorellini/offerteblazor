using System.ComponentModel.DataAnnotations.Schema;

namespace OfferteWeb.Models
{
    public partial class Agente
    {
        [NotMapped]
        public DateTime? ExpirationDate { get; set; }
        [NotMapped]
        public byte[] Avatar { get; set; }
        [NotMapped]
        public bool Expiring { get; set; }
        [NotMapped]
        public bool Disabled { get; set; }
        [NotMapped]
        public string Role { get; set; }
        [NotMapped]
        public string Username { get; set; }
        [NotMapped]
        public bool DirittoSede { get; internal set; }
        [NotMapped]
        public string Token { get; internal set; }
    }
}
