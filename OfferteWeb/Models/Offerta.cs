using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Offerta
{
    public long Id { get; set; }

    public long IdUtente { get; set; }

    public long IdAgente { get; set; }

    public DateTime? DataOfferta { get; set; }

    public string? MatricolCliente { get; set; }

    public string? CodiceInterno { get; set; }

    public long IdCliente { get; set; }

    public double? DimXfigura { get; set; }

    public double? DimYfigura { get; set; }

    public double? DimTaglioX { get; set; }

    public double? DimTaglioY { get; set; }

    public double? DimXsbordato { get; set; }

    public double? DimYsbordato { get; set; }

    public short? NumCircuitiXcart { get; set; }

    public short? NumCircuitiYcart { get; set; }

    public long? IdTipoProdotto { get; set; }

    public short? Criticita { get; set; }

    public double? InterspazioMassimo { get; set; }

    public double? InterspazioMinimo { get; set; }

    public double? BordoTecnicoMassimo { get; set; }

    public double? BordoTecnicoMinimo { get; set; }

    public long? IdMaterialeTec { get; set; }

    public long? SpessRame { get; set; }

    public long? SpessoreFinale { get; set; }

    public long? FinituraSuperficiale { get; set; }

    public long? FinituraMeccanica { get; set; }

    public short? NumeroAsole { get; set; }

    public short? DoraturaContattiera { get; set; }

    public byte? StatoOfferta { get; set; }

    public long? Solder { get; set; }

    public long? TipoSolder { get; set; }

    public long? Serigrafia { get; set; }

    public long? ColoreSerigrafia { get; set; }

    public short? NumForiPerCartella { get; set; }

    public double? DiametroMinForo { get; set; }

    public double? DiametroMaxForo { get; set; }

    public long? TestElettrico { get; set; }

    public byte? TestSondeMobili { get; set; }

    public short? NumTagliScoring { get; set; }

    public double? ScartoPrevisto { get; set; }

    public DateTime DataScadenzaOfferta { get; set; }

    public long? IdValuta { get; set; }

    public double? PerimetroFresatura { get; set; }

    public string? FormaDiPagamento { get; set; }

    public string? Trasporto { get; set; }

    public bool OttimizzaInUnVerso { get; set; }

    public long? Pelabile { get; set; }

    public string? CondizioniResa { get; set; }

    public string? Note { get; set; }

    public bool Attrezzatura { get; set; }

    public bool AttrezzaturaTest { get; set; }

    public bool FresaSi { get; set; }

    public bool MicroForatura { get; set; }

    public bool FineLine { get; set; }

    public double? AttrezzaturaAdd { get; set; }

    public double? AttrezzaturaTestAdd { get; set; }

    public string? Riferimento { get; set; }

    public string? Destinatario { get; set; }

    public bool ControlloSede { get; set; }

    public string? Listino { get; set; }

    public bool FModificata { get; set; }

    public DateTime? DataUltimaModifica { get; set; }

    public string? RevisioneDocumento { get; set; }

    public long? Grafite { get; set; }

    public bool PressFit { get; set; }

    public long? Tendinatura { get; set; }

    public short? SeqForiCiechi { get; set; }

    public short? SeqForiInterrati { get; set; }

    public bool ImpedenzaControllata { get; set; }

    public double? CostoLottoCina { get; set; }

    public long? ValutaAcquisto { get; set; }

    public long? IdTrasporto { get; set; }

    public long? IdResa { get; set; }

    public string? NoteCina { get; set; }

    public long? IdFornitore { get; set; }

    public long? IdTipoPagamento { get; set; }

    public long? IdTrasportatore { get; set; }

    public long? IdStatoFarEast { get; set; }

    public string? NoteCommerciali { get; set; }

    public long? IdFollowUp { get; set; }

    public string? NoteFollowUp { get; set; }

    public long? IdLingua { get; set; }

    public long? IdTrasportoIta { get; set; }

    public string? CodNazione { get; set; }

    public string? CodMezzo { get; set; }

    public bool Stencil { get; set; }

    public double? AttrezzaturaStencil { get; set; }

    public int? NumeroStencil { get; set; }

    public string? NoteMontaggio { get; set; }

    public long? IdTipoRigidoDf { get; set; }

    public long? SpessoreInnerLayer { get; set; }

    public long? SpessRameInnerLayer { get; set; }

    public string? NoteMaster { get; set; }

    public bool FTunisia { get; set; }

    public string? NoteInterne { get; set; }

    public bool ProgrammiMacchina { get; set; }

    public double? MinProgrammiMacchina { get; set; }

    public int? ComponentiSmd { get; set; }

    public int? ComponentiPth { get; set; }

    /// <summary>
    /// riporta il legacy numeroOfferta
    /// </summary>
    public int? NumeroOfferta { get; set; }

    public virtual ColoreSerigrafia? ColoreSerigrafiaNavigation { get; set; }

    public virtual FinituraMeccanica? FinituraMeccanicaNavigation { get; set; }

    public virtual FinituraSuperficiale? FinituraSuperficialeNavigation { get; set; }

    public virtual Grafite? GrafiteNavigation { get; set; }

    public virtual Agente IdAgenteNavigation { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Followup? IdFollowUpNavigation { get; set; }

    public virtual Fornitore? IdFornitoreNavigation { get; set; }

    public virtual Lingua? IdLinguaNavigation { get; set; }

    public virtual Materiale? IdMaterialeTecNavigation { get; set; }

    public virtual Resa? IdResaNavigation { get; set; }

    public virtual StatoFarEast? IdStatoFarEastNavigation { get; set; }

    public virtual TipoPagamento? IdTipoPagamentoNavigation { get; set; }

    public virtual TipoProdotto? IdTipoProdottoNavigation { get; set; }

    public virtual TipoRigido? IdTipoRigidoDfNavigation { get; set; }

    public virtual Trasportatore? IdTrasportatoreNavigation { get; set; }

    public virtual Trasporto? IdTrasportoItaNavigation { get; set; }

    public virtual Trasporto? IdTrasportoNavigation { get; set; }

    public virtual Valuta? IdValutaNavigation { get; set; }

    public virtual ICollection<OffertaMontaggio> OffertaMontaggio { get; set; } = new List<OffertaMontaggio>();

    public virtual ICollection<OffertaRiga> OffertaRiga { get; set; } = new List<OffertaRiga>();

    public virtual ICollection<OffertaRigaFarEast> OffertaRigaFarEast { get; set; } = new List<OffertaRigaFarEast>();

    public virtual Pelabile? PelabileNavigation { get; set; }

    public virtual Serigrafia? SerigrafiaNavigation { get; set; }

    public virtual Solder? SolderNavigation { get; set; }

    public virtual Tendinatura? TendinaturaNavigation { get; set; }

    public virtual TestElettrico? TestElettricoNavigation { get; set; }

    public virtual TipoSolder? TipoSolderNavigation { get; set; }
}
