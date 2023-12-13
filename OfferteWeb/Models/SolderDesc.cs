using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class SolderDesc
{
    public long Id { get; set; }

    public long IdLingua { get; set; }

    public string? Descrizione { get; set; }

    public virtual Lingua IdLinguaNavigation { get; set; } = null!;

    public virtual Solder IdNavigation { get; set; } = null!;
}
