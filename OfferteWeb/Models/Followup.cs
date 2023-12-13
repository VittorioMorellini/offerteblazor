using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Followup
{
    public long Id { get; set; }

    public string? Descrizione { get; set; }

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();
}
