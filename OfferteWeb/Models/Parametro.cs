using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Parametro
{
    public string Codice { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string? Valore { get; set; }
}
