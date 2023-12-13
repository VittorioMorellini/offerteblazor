using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class PreCalcolo
{
    public string Nome { get; set; } = null!;

    public string Formula { get; set; } = null!;

    public int? Ordinamento { get; set; }
}
