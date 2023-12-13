using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Valuta
{
    public long Id { get; set; }

    public string? DescrBreve { get; set; }

    public string? Descrizione { get; set; }

    public double? CambioEuro { get; set; }

    public short? ValutaOmega { get; set; }

    public string? DummyPoof { get; set; }

    public string? Codice { get; set; }

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();
}
