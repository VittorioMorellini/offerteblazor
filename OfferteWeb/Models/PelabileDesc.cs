using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class PelabileDesc
{
    public long Id { get; set; }

    public long IdLingua { get; set; }

    public string? Descrizione { get; set; }

    public virtual Lingua IdLinguaNavigation { get; set; } = null!;

    public virtual Pelabile IdNavigation { get; set; } = null!;
}
