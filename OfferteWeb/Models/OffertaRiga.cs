using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class OffertaRiga
{
    public long Id { get; set; }

    public long IdOfferta { get; set; }

    public int? Quantita { get; set; }

    public int? CircuitiBuoniAttesi { get; set; }

    public int? CircuitiDaProdurre { get; set; }

    public double? CostoQuadrottoVal { get; set; }

    public double? CostoQuadrottoEuro { get; set; }

    public double? CostoCircuitoVal { get; set; }

    public double? CostoCircuitoEuro { get; set; }

    public double? PrezzoVenditaVal { get; set; }

    public double? PrezzoVenditaEuro { get; set; }

    public double? CostoLottoVal { get; set; }

    public double? CostoLottoEuro { get; set; }

    public int? GiorniDiConsegna { get; set; }

    public double? Tolleranza { get; set; }

    public int? NumQuadrotti { get; set; }

    public double? MetriQuadratiVend { get; set; }

    public double? PrezzoLottoVal { get; set; }

    public double? PrezzoLottoEuro { get; set; }

    public double? PrezzoDcmQval { get; set; }

    public double? PrezzoDcmQeuro { get; set; }

    public bool Campione { get; set; }

    public double? PrezzoSingoloEuro { get; set; }

    public double? PrezzoSingoloVal { get; set; }

    public DateTime? DataQuotazione { get; set; }

    public bool CampioneEstero { get; set; }

    public double? Peso { get; set; }

    public double? CostoTrasporto { get; set; }

    public double? Sconto { get; set; }

    public byte? SondeMobili { get; set; }

    public bool TrasportoManuale { get; set; }

    public double? CostoTraspManuale { get; set; }

    public bool FCinaAereo { get; set; }

    public bool FCinaNave { get; set; }

    public bool FCinaBlind { get; set; }

    public bool FCinaFast { get; set; }

    public double? PrezzoComp { get; set; }

    public double? PrezzoMontaggi { get; set; }

    public double? PrezzoCollaudi { get; set; }

    public double? CostoAcquisto { get; set; }

    public bool FFobHk { get; set; }

    public double? Benefit { get; set; }

    public double? AumentoPerSconto { get; set; }

    public double? ScontoCliente { get; set; }

    public double? ValoreTotaleCina { get; set; }

    public double? ValoreCinaAumentato { get; set; }

    public double? PrezzoVenditaCina { get; set; }

    public double? ValoreComplessivoFin { get; set; }

    public double? TempoMontTop { get; set; }

    public double? TempoMontBottom { get; set; }

    public double? TempoSetupTop { get; set; }

    public double? TempoSetupBottom { get; set; }

    public double? NumProgrammiMacchina { get; set; }

    public double? CostoOraTestCollaudo { get; set; }

    public double? MinutiCollaudo { get; set; }

    public double? NumeroOre { get; set; }

    public double? Rettifica { get; set; }

    public double? CostoAcqCina { get; set; }

    public double? CostoTraspCina { get; set; }

    public double? Margine { get; set; }

    public double? MinutiPth { get; set; }

    public double? MinutiImballo { get; set; }

    public double? AttrezzaturaCina { get; set; }

    public double? MetriQuadri { get; set; }

    public double? MinutiSmd { get; set; }

    public double? MinutiSetup { get; set; }

    public double? TotaleCostoLavoro { get; set; }

    public double? RicavoComponenti { get; set; }

    public double? TotaleRicavoLavoro { get; set; }

    public double? RicavoAttrezzatura { get; set; }

    public double? RicavoStencil { get; set; }

    public double? RicavoPrgMacchina { get; set; }

    public double? RicavoAttrezzTest { get; set; }

    public int? CircuitiLanciati { get; set; }

    public virtual Offerta IdOffertaNavigation { get; set; } = null!;
}
