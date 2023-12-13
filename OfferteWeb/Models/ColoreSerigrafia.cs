using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class ColoreSerigrafia
{
    public long Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<ColoreSerigrafiaDesc> ColoreSerigrafiaDesc { get; set; } = new List<ColoreSerigrafiaDesc>();

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();
}
