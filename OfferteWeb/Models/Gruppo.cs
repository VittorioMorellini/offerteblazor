using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Gruppo
{
    public long Id { get; set; }

    public string? Descrizione { get; set; }

    public bool DirittoSede { get; set; }

    public virtual ICollection<AgenteGruppo> AgenteGruppo { get; set; } = new List<AgenteGruppo>();
}
