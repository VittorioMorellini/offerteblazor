using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class FormatoStandard
{
    public long Id { get; set; }

    public bool Standard { get; set; }

    public double DimensioneX { get; set; }

    public double DimensioneY { get; set; }

    public double DimensioneXsbordato { get; set; }

    public double DimensioneYsbordato { get; set; }
}
