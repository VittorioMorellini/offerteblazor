using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class FornitoreDocumentoMail
{
    public long IdFornitore { get; set; }

    public long IdDocumentoMail { get; set; }

    public string? IndirizzoMail { get; set; }

    public virtual DocumentoMail IdDocumentoMailNavigation { get; set; } = null!;

    public virtual Fornitore IdFornitoreNavigation { get; set; } = null!;
}
