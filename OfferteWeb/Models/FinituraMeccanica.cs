using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class FinituraMeccanica
{
    public long Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<FinituraMeccanicaDesc> FinituraMeccanicaDesc { get; set; } = new List<FinituraMeccanicaDesc>();

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();
}
