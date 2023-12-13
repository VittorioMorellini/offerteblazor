using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class CliCom
{
    public int Id { get; set; }

    public string? RagioneSociale { get; set; }

    public string? Indirizzo { get; set; }

    public string? Cap { get; set; }

    public string? Localita { get; set; }

    public string? CodiceFiscale { get; set; }

    public string? PartitaIva { get; set; }

    public string? FormaDiPagamento { get; set; }

    public string? BancaAppoggio { get; set; }

    public string? RagioneSociale2 { get; set; }

    public string? Indirizzo2 { get; set; }

    public string? Cap2 { get; set; }

    public string? Localita2 { get; set; }

    public string? Vettore { get; set; }

    public byte? MaxGgRitCons { get; set; }

    public double? Budget { get; set; }

    public bool? Italia { get; set; }

    public short? CodiceListino { get; set; }

    public bool? Esportatore { get; set; }

    public short? Zona { get; set; }

    public short? Valuta { get; set; }

    public int? NonUsato5 { get; set; }

    public short? CodiceAgente { get; set; }

    public double? Sconto { get; set; }

    public byte? SettoreMerc { get; set; }

    public byte? Priorita { get; set; }

    public bool? SpedAltroInd { get; set; }

    public bool? InfoParticolari { get; set; }

    public string? Telefono { get; set; }

    public string? Contattare { get; set; }

    public string? CodiceContabile { get; set; }

    public bool? Disattivato { get; set; }

    public bool? DaNonServire { get; set; }

    public string? NumeroFax { get; set; }

    public string? EMail { get; set; }

    public short? IdMinimoComm { get; set; }

    public short? IdTolleranza { get; set; }

    public string? DummyPoof { get; set; }
}
