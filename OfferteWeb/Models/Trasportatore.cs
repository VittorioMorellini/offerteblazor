using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Trasportatore
{
    public long Id { get; set; }

    public string? Descrizione { get; set; }

    public string? IndirizzoMail { get; set; }

    public long? IdTrasporto { get; set; }

    public virtual Trasporto? IdTrasportoNavigation { get; set; }

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();

    public virtual ICollection<OffertaRigaFarEast> OffertaRigaFarEast { get; set; } = new List<OffertaRigaFarEast>();
}
