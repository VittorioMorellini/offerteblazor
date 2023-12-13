using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class AgenteGruppo
{
    public long Id { get; set; }

    public long IdAgente { get; set; }

    public long IdGruppo { get; set; }

    public short? Ausilio { get; set; }

    public virtual Agente IdAgenteNavigation { get; set; } = null!;

    public virtual Gruppo IdGruppoNavigation { get; set; } = null!;
}
