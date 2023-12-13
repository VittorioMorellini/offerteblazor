using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class TipoProdotto
{
    public long Id { get; set; }

    public string? Descrizione { get; set; }

    public string? CodicePerLayup { get; set; }

    public int? NumFacce { get; set; }

    public int? NumStrati { get; set; }

    public double? PesoKgmetroQ { get; set; }

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();
}
