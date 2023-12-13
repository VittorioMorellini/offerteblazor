using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class CirCom
{
    public int? CodiceEdp { get; set; }

    public string? MatricolaCliente { get; set; }

    public string? CodiceInterno { get; set; }

    public short? CodiceCliente { get; set; }

    public double? PrezzoUnitario { get; set; }

    public double? Attrezzatura { get; set; }

    public double? UltimaQtaOrdinata { get; set; }

    public DateTime? UltimaDataConsegna { get; set; }

    public double? QtaMagLibera { get; set; }

    public double? QtaMagImpegnata { get; set; }

    public double? SuperficieSingola { get; set; }

    public bool? NuovaLavorazione { get; set; }

    public bool? Campione { get; set; }

    public double? Provvigione { get; set; }

    public short? TollSpedizione { get; set; }

    public string? Disegno { get; set; }

    public string? DummyPoof { get; set; }
}
