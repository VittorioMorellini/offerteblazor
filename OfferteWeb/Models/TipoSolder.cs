using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class TipoSolder
{
    public long Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();

    public virtual ICollection<TipoSolderDesc> TipoSolderDesc { get; set; } = new List<TipoSolderDesc>();
}
