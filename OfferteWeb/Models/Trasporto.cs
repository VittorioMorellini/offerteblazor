using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Trasporto
{
    public long Id { get; set; }

    public string? Descrizione { get; set; }

    public double? CostoUnitario { get; set; }

    public short? GiorniConsegna { get; set; }

    public string? Codice { get; set; }

    public long? IdCorrispondente { get; set; }

    public bool EscludiFestivita { get; set; }

    public virtual Corrispondente? IdCorrispondenteNavigation { get; set; }

    public virtual ICollection<Offerta> OffertaIdTrasportoItaNavigation { get; set; } = new List<Offerta>();

    public virtual ICollection<Offerta> OffertaIdTrasportoNavigation { get; set; } = new List<Offerta>();

    public virtual ICollection<OffertaRigaFarEast> OffertaRigaFarEast { get; set; } = new List<OffertaRigaFarEast>();

    public virtual ICollection<Trasportatore> Trasportatore { get; set; } = new List<Trasportatore>();
}
