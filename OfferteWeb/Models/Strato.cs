using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Strato
{
    public long Id { get; set; }

    public int? Facce { get; set; }

    public int? Campione { get; set; }

    public int? Veloce { get; set; }

    public string? Descrizione { get; set; }
}
