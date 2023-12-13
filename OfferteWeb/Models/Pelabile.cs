using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Pelabile
{
    public long Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();

    public virtual ICollection<PelabileDesc> PelabileDesc { get; set; } = new List<PelabileDesc>();
}
