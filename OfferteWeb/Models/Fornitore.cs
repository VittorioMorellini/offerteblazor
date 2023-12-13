using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Fornitore
{
    public long Id { get; set; }

    public string? RagioneSociale { get; set; }

    public string? Indirizzo { get; set; }

    public long? IdTipoPagamento { get; set; }

    public string? IndirizzoMail { get; set; }

    public virtual ICollection<FornitoreDocumentoMail> FornitoreDocumentoMail { get; set; } = new List<FornitoreDocumentoMail>();

    public virtual TipoPagamento? IdTipoPagamentoNavigation { get; set; }

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();

    public virtual ICollection<OffertaRigaFarEast> OffertaRigaFarEast { get; set; } = new List<OffertaRigaFarEast>();
}
