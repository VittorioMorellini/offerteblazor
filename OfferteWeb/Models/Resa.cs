using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Resa
{
    public long Id { get; set; }

    public string? Descrizione { get; set; }

    public bool CostoZero { get; set; }

    public string? Codice { get; set; }

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();
}
