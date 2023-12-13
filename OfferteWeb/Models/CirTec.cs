using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class CirTec
{
    public int? CodiceEdp { get; set; }

    public int? CodiceMaschera { get; set; }

    public short? Mult1X { get; set; }

    public short? Mult1Y { get; set; }

    public double? MaggMas1X { get; set; }

    public double? MaggMas1Y { get; set; }

    public double? Bordo1X { get; set; }

    public double? Bordo1Y { get; set; }

    public short? Mult2X { get; set; }

    public short? Mult2Y { get; set; }

    public double? MaggMas2X { get; set; }

    public double? MaggMas2Y { get; set; }

    public double? Bordo2X { get; set; }

    public double? Bordo2Y { get; set; }

    public short? CodiceFormato { get; set; }

    public bool? ForiDaAggiungere { get; set; }

    public DateTime? DataUltimoUso { get; set; }

    public double? OrigineMadreX { get; set; }

    public double? OrigineMadreY { get; set; }

    public int? NumForiNonPasso { get; set; }

    public int? NumDiametriNonPasso { get; set; }

    public int? NumForiPasso { get; set; }

    public int? NumDiametriPasso { get; set; }

    public double? Densita { get; set; }

    public short? CodiceMaterialeTec { get; set; }

    public short? Pacchi { get; set; }

    public short? DiamMinimoNonPasso { get; set; }

    public short? DiamMinimoPasso { get; set; }

    public short? SpessoreRame { get; set; }

    public string? LatoConnettore { get; set; }

    public double? DimTaglioX { get; set; }

    public double? DimTaglioY { get; set; }

    public short? CicloLavorazione { get; set; }

    public short? ImpaginazioneX { get; set; }

    public short? ImpaginazioneY { get; set; }

    public string? StringaTaglio { get; set; }

    public byte? NumeroSpine { get; set; }

    public string? CodiceLayUp { get; set; }

    public double? TempoPacco { get; set; }

    public short? FinituraSuperficiale { get; set; }

    public short? SpessoreMateriale { get; set; }

    public short? Facce { get; set; }

    public short? Strati { get; set; }

    public short? Galvanica { get; set; }

    public short? Fingers { get; set; }

    public short? StampeAggiuntive { get; set; }

    public short? TipoSolder { get; set; }

    public short? ColoreSerigrafia { get; set; }

    public short? FinituraMeccanica { get; set; }

    public bool? Metallizzazione { get; set; }

    public byte? Testing { get; set; }

    public bool? MarchioUl { get; set; }

    public bool? TestEsterno { get; set; }

    public int? NumFigure { get; set; }

    public string? FileForatura { get; set; }

    public short? DiametroSpine { get; set; }

    public double? QuotaSpineX1 { get; set; }

    public double? QuotaSpineY1 { get; set; }

    public double? QuotaSpineX2 { get; set; }

    public double? QuotaSpineY2 { get; set; }

    public short? Tool1 { get; set; }

    public short? Diametro1 { get; set; }

    public short? Tool2 { get; set; }

    public short? Diametro2 { get; set; }

    public short? Tool3 { get; set; }

    public short? Diametro3 { get; set; }

    public short? Tool4 { get; set; }

    public short? Diametro4 { get; set; }

    public double? MetriFresatura { get; set; }

    public string? TipoTestElettrico { get; set; }

    public short? TenumAdattatore { get; set; }

    public short? TenumPuntiTest { get; set; }

    public double? QuotaScoringX { get; set; }

    public double? QuotaScoringY { get; set; }

    public short? TagliCircuitoX { get; set; }

    public short? TagliCircuitoY { get; set; }

    public short? TagliQuadrottoX { get; set; }

    public short? TagliQuadrottoY { get; set; }

    public string? DorContattiera { get; set; }

    public int? NumeroAsole { get; set; }

    public byte? Tendinatura { get; set; }

    public byte? Grafite { get; set; }

    public bool? PressFit { get; set; }

    public short? ForiCiechi { get; set; }

    public short? ForiInterrati { get; set; }

    public bool? FineLine { get; set; }

    public double? ForoMinimo { get; set; }

    public bool? Microforatura { get; set; }

    public double? PistaMinima { get; set; }

    public double? IsolamMin { get; set; }

    public bool? Gerber { get; set; }

    public int? NumeroFori { get; set; }

    public bool? Rottamare { get; set; }

    public string? UsoFuturo { get; set; }

    public string? DirAllegati { get; set; }

    public bool? Campione { get; set; }

    public bool? Rilancio { get; set; }
}
