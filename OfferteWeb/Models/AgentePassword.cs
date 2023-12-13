using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class AgentePassword
{
    public long IdAgente { get; set; }

    public bool DirittoSupervisore { get; set; }

    public string? Password { get; set; }

    public bool DirittoSede { get; set; }

    public string? IndirizzoMail { get; set; }

    public string? PassworddMail { get; set; }

    public bool DirittoFarEast { get; set; }

    public virtual Agente IdAgenteNavigation { get; set; } = null!;
}
