using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Solder
{
    public long Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();

    public virtual ICollection<SolderDesc> SolderDesc { get; set; } = new List<SolderDesc>();
}
