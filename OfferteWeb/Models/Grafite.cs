using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Grafite
{
    public long Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<GrafiteDesc> GrafiteDesc { get; set; } = new List<GrafiteDesc>();

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();
}
