using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Corrispondente
{
    public long Id { get; set; }

    public string? Descrizione { get; set; }

    public string? IndirizzoMail { get; set; }

    public virtual ICollection<Trasporto> Trasporto { get; set; } = new List<Trasporto>();
}
