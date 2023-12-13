using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Cliente
{
    public long Id { get; set; }

    public long? IdTrasporto { get; set; }

    public string? CodMezzo { get; set; }

    public double? Tolleranza { get; set; }

    public string? CodNazione { get; set; }

    public string? CodClienteAhr { get; set; }

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();
}
