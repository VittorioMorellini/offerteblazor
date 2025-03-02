using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OfferteWeb.Models;

public partial class OfferteDbContext : DbContext
{
    public OfferteDbContext(DbContextOptions<OfferteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agente> Agente { get; set; }

    public virtual DbSet<AgenteGruppo> AgenteGruppo { get; set; }

    public virtual DbSet<AgentePassword> AgentePassword { get; set; }

    public virtual DbSet<AumentoFarEast> AumentoFarEast { get; set; }

    public virtual DbSet<CalcoloFarEast> CalcoloFarEast { get; set; }

    public virtual DbSet<CirCom> CirCom { get; set; }

    public virtual DbSet<CirTec> CirTec { get; set; }

    public virtual DbSet<CliCom> CliCom { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<ColoreSerigrafia> ColoreSerigrafia { get; set; }

    public virtual DbSet<ColoreSerigrafiaDesc> ColoreSerigrafiaDesc { get; set; }

    public virtual DbSet<Corrispondente> Corrispondente { get; set; }

    public virtual DbSet<CostoAcquisto> CostoAcquisto { get; set; }

    public virtual DbSet<DocumentoMail> DocumentoMail { get; set; }

    public virtual DbSet<FinituraMeccanica> FinituraMeccanica { get; set; }

    public virtual DbSet<FinituraMeccanicaDesc> FinituraMeccanicaDesc { get; set; }

    public virtual DbSet<FinituraSuperficiale> FinituraSuperficiale { get; set; }

    public virtual DbSet<FinituraSuperficialeDesc> FinituraSuperficialeDesc { get; set; }

    public virtual DbSet<Followup> Followup { get; set; }

    public virtual DbSet<FormatoStandard> FormatoStandard { get; set; }

    public virtual DbSet<Fornitore> Fornitore { get; set; }

    public virtual DbSet<FornitoreDocumentoMail> FornitoreDocumentoMail { get; set; }

    public virtual DbSet<Grafite> Grafite { get; set; }

    public virtual DbSet<GrafiteDesc> GrafiteDesc { get; set; }

    public virtual DbSet<Gruppo> Gruppo { get; set; }

    public virtual DbSet<Label> Label { get; set; }

    public virtual DbSet<Lingua> Lingua { get; set; }

    public virtual DbSet<Materiale> Materiale { get; set; }

    public virtual DbSet<Mezzo> Mezzo { get; set; }

    public virtual DbSet<Offerta> Offerta { get; set; }

    public virtual DbSet<OffertaMontaggio> OffertaMontaggio { get; set; }

    public virtual DbSet<OffertaRiga> OffertaRiga { get; set; }

    public virtual DbSet<OffertaRigaFarEast> OffertaRigaFarEast { get; set; }

    public virtual DbSet<Parametro> Parametro { get; set; }

    public virtual DbSet<Pelabile> Pelabile { get; set; }

    public virtual DbSet<PelabileDesc> PelabileDesc { get; set; }

    public virtual DbSet<PostCalcolo> PostCalcolo { get; set; }

    public virtual DbSet<PreCalcolo> PreCalcolo { get; set; }

    public virtual DbSet<Resa> Resa { get; set; }

    public virtual DbSet<Serigrafia> Serigrafia { get; set; }

    public virtual DbSet<SerigrafiaDesc> SerigrafiaDesc { get; set; }

    public virtual DbSet<Solder> Solder { get; set; }

    public virtual DbSet<SolderDesc> SolderDesc { get; set; }

    public virtual DbSet<SpessoreMateriale> SpessoreMateriale { get; set; }

    public virtual DbSet<SpessoreRame> SpessoreRame { get; set; }

    public virtual DbSet<StatoFarEast> StatoFarEast { get; set; }

    public virtual DbSet<Strato> Strato { get; set; }

    public virtual DbSet<Tendinatura> Tendinatura { get; set; }

    public virtual DbSet<TendinaturaDesc> TendinaturaDesc { get; set; }

    public virtual DbSet<TestElettrico> TestElettrico { get; set; }

    public virtual DbSet<TestElettricoDesc> TestElettricoDesc { get; set; }

    public virtual DbSet<TipoPagamento> TipoPagamento { get; set; }

    public virtual DbSet<TipoProdotto> TipoProdotto { get; set; }

    public virtual DbSet<TipoRigido> TipoRigido { get; set; }

    public virtual DbSet<TipoRigidoDesc> TipoRigidoDesc { get; set; }

    public virtual DbSet<TipoSolder> TipoSolder { get; set; }

    public virtual DbSet<TipoSolderDesc> TipoSolderDesc { get; set; }

    public virtual DbSet<Trasportatore> Trasportatore { get; set; }

    public virtual DbSet<Trasporto> Trasporto { get; set; }

    public virtual DbSet<Valuta> Valuta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Agente>(entity =>
        {
            entity.HasIndex(e => e.RagioneSociale, "key1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cap)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.CodiceFiscale)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Cognome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Localita)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroFax)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.PartitaIva)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("PartitaIVA");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordMail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RagioneSociale)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(18)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AgenteGruppo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgenteGr__3214EC077F2BE32F");

            entity.HasOne(d => d.IdAgenteNavigation).WithMany(p => p.AgenteGruppo)
                .HasForeignKey(d => d.IdAgente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AgenteGru__IdAge__29E1370A");

            entity.HasOne(d => d.IdGruppoNavigation).WithMany(p => p.AgenteGruppo)
                .HasForeignKey(d => d.IdGruppo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AgenteGru__IdGru__0A338187");
        });

        modelBuilder.Entity<AgentePassword>(entity =>
        {
            entity.HasKey(e => e.IdAgente).HasName("PK__AgentePa__FAD2D3A60B91BA14");

            entity.Property(e => e.IdAgente).ValueGeneratedNever();
            entity.Property(e => e.IndirizzoMail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PassworddMail)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAgenteNavigation).WithOne(p => p.AgentePassword)
                .HasForeignKey<AgentePassword>(d => d.IdAgente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AgentePas__IdAge__0B27A5C0");
        });

        modelBuilder.Entity<AumentoFarEast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AumentoF__3214EC0731B762FC");
        });

        modelBuilder.Entity<CalcoloFarEast>(entity =>
        {
            entity.HasKey(e => e.Nome).HasName("PK__CalcoloF__7D8FE3B32A164134");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Formula)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CirCom>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.CodiceEdp, "key0").IsUnique();

            entity.HasIndex(e => e.MatricolaCliente, "key1");

            entity.HasIndex(e => e.CodiceInterno, "key2").IsUnique();

            entity.HasIndex(e => e.CodiceCliente, "key3");

            entity.Property(e => e.CodiceEdp).HasColumnName("CodiceEDP");
            entity.Property(e => e.CodiceInterno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Disegno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DummyPoof)
                .HasMaxLength(72)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MatricolaCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UltimaDataConsegna).HasColumnType("datetime");
        });

        modelBuilder.Entity<CirTec>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.CodiceEdp, "IX_EDP").IsUnique();

            entity.Property(e => e.CodiceEdp).HasColumnName("CodiceEDP");
            entity.Property(e => e.CodiceLayUp)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.DataUltimoUso).HasColumnType("datetime");
            entity.Property(e => e.DirAllegati)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DorContattiera)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FileForatura)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LatoConnettore)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MarchioUl).HasColumnName("MarchioUL");
            entity.Property(e => e.StringaTaglio)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenumAdattatore).HasColumnName("TENumAdattatore");
            entity.Property(e => e.TenumPuntiTest).HasColumnName("TENumPuntiTest");
            entity.Property(e => e.TipoTestElettrico)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UsoFuturo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<CliCom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CliCom__3214EC07173876EA");

            entity.HasIndex(e => e.RagioneSociale, "key1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BancaAppoggio)
                .HasMaxLength(52)
                .IsUnicode(false);
            entity.Property(e => e.Cap)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Cap2)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.CodiceContabile)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodiceFiscale)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Contattare)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.DummyPoof)
                .HasMaxLength(141)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("eMail");
            entity.Property(e => e.FormaDiPagamento)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Indirizzo2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Localita)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Localita2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.NumeroFax)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PartitaIva)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("PartitaIVA");
            entity.Property(e => e.RagioneSociale)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RagioneSociale2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Vettore)
                .HasMaxLength(18)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC0707020F21");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CodClienteAhr)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CodMezzo)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CodNazione)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ColoreSerigrafia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ColoreSe__3214EC075070F446");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ColoreSerigrafiaDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__ColoreSe__3985682840F9A68C");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.ColoreSerigrafiaDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ColoreSerigr__Id__0C1BC9F9");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.ColoreSerigrafiaDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ColoreSer__IdLin__1881A0DE");
        });

        modelBuilder.Entity<Corrispondente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Corrispo__3214EC072DE6D218");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IndirizzoMail)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CostoAcquisto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CostoAcq__3214EC072645B050");
        });

        modelBuilder.Entity<DocumentoMail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC071EA48E88");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FinituraMeccanica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Finitura__3214EC07398D8EEE");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FinituraMeccanicaDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__Finitura__3985682844CA3770");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.FinituraMeccanicaDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FinituraMecc__Id__0D0FEE32");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.FinituraMeccanicaDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FinituraM__IdLin__178D7CA5");
        });

        modelBuilder.Entity<FinituraSuperficiale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Finitura__3214EC0735BCFE0A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FinituraSuperficialeDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__Finitura__39856828489AC854");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.FinituraSuperficialeDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FinituraSupe__Id__0E04126B");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.FinituraSuperficialeDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FinituraS__IdLin__1699586C");
        });

        modelBuilder.Entity<Followup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Followup__3214EC07778AC167");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FormatoStandard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FormatoS__3214EC073D2915A8");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DimensioneXsbordato).HasColumnName("DimensioneXSbordato");
            entity.Property(e => e.DimensioneYsbordato).HasColumnName("DimensioneYSbordato");
        });

        modelBuilder.Entity<Fornitore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fornitor__3214EC076FE99F9F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IndirizzoMail)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.RagioneSociale)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoPagamentoNavigation).WithMany(p => p.Fornitore)
                .HasForeignKey(d => d.IdTipoPagamento)
                .HasConstraintName("FK__Fornitore__IdTip__10E07F16");
        });

        modelBuilder.Entity<FornitoreDocumentoMail>(entity =>
        {
            entity.HasKey(e => new { e.IdFornitore, e.IdDocumentoMail }).HasName("PK__Fornitor__4052F42422751F6C");

            entity.Property(e => e.IndirizzoMail)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDocumentoMailNavigation).WithMany(p => p.FornitoreDocumentoMail)
                .HasForeignKey(d => d.IdDocumentoMail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fornitore__IdDoc__12C8C788");

            entity.HasOne(d => d.IdFornitoreNavigation).WithMany(p => p.FornitoreDocumentoMail)
                .HasForeignKey(d => d.IdFornitore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fornitore__IdFor__11D4A34F");
        });

        modelBuilder.Entity<Grafite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grafite__3214EC075BE2A6F2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GrafiteDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__GrafiteD__398568284C6B5938");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.GrafiteDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GrafiteDesc__Id__13BCEBC1");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.GrafiteDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GrafiteDe__IdLin__14B10FFA");
        });

        modelBuilder.Entity<Gruppo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gruppo__3214EC077B5B524B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Label>(entity =>
        {
            entity.HasKey(e => new { e.IdLingua, e.Id }).HasName("PK__Label__DA390C310F624AF8");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.Label)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Label__IdLingua__15A53433");
        });

        modelBuilder.Entity<Lingua>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LINGUA__3214EC0702FC7413");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Materiale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3214EC0722AA2996");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Codice)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mezzo>(entity =>
        {
            entity.HasKey(e => e.Codice).HasName("PK__Mezzo__0636EC1C3587F3E0");

            entity.Property(e => e.Codice)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Offerta>(entity =>
        {
            entity.Property(e => e.CodMezzo)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CodNazione)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodiceInterno)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CondizioniResa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DataOfferta).HasColumnType("datetime");
            entity.Property(e => e.Destinatario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DimXfigura).HasColumnName("DimXFigura");
            entity.Property(e => e.DimXsbordato).HasColumnName("DimXSbordato");
            entity.Property(e => e.DimYfigura).HasColumnName("DimYFigura");
            entity.Property(e => e.DimYsbordato).HasColumnName("DimYSbordato");
            entity.Property(e => e.FModificata).HasColumnName("fModificata");
            entity.Property(e => e.FTunisia).HasColumnName("fTunisia");
            entity.Property(e => e.FormaDiPagamento)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.IdTipoRigidoDf).HasColumnName("IdTipoRigidoDF");
            entity.Property(e => e.Listino)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MatricolCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Note)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NoteCina)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NoteCommerciali).HasColumnType("text");
            entity.Property(e => e.NoteFollowUp)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NoteInterne)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NoteMaster).HasColumnType("text");
            entity.Property(e => e.NoteMontaggio).HasColumnType("text");
            entity.Property(e => e.NumCircuitiXcart).HasColumnName("NumCircuitiXCart");
            entity.Property(e => e.NumCircuitiYcart).HasColumnName("NumCircuitiYCart");
            entity.Property(e => e.NumeroOfferta).HasComment("riporta il legacy numeroOfferta");
            entity.Property(e => e.RevisioneDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Riferimento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Trasporto)
                .HasMaxLength(18)
                .IsUnicode(false);

            entity.HasOne(d => d.ColoreSerigrafiaNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.ColoreSerigrafia)
                .HasConstraintName("FK__Offerta__ColoreS__30592A6F");

            entity.HasOne(d => d.FinituraMeccanicaNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.FinituraMeccanica)
                .HasConstraintName("FK__Offerta__Finitur__2B947552");

            entity.HasOne(d => d.FinituraSuperficialeNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.FinituraSuperficiale)
                .HasConstraintName("FK__Offerta__Finitur__2AA05119");

            entity.HasOne(d => d.GrafiteNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.Grafite)
                .HasConstraintName("FK__Offerta__Grafite__567ED357");

            entity.HasOne(d => d.IdAgenteNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdAgente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Offerta__IdAgent__26CFC035");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Offerta__IdClien__27C3E46E");

            entity.HasOne(d => d.IdFollowUpNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdFollowUp)
                .HasConstraintName("FK__Offerta__IdFollo__3AD6B8E2");

            entity.HasOne(d => d.IdFornitoreNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdFornitore)
                .HasConstraintName("FK__Offerta__IdForni__351DDF8C");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdLingua)
                .HasConstraintName("FK__Offerta__IdLingu__3BCADD1B");

            entity.HasOne(d => d.IdMaterialeTecNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdMaterialeTec)
                .HasConstraintName("FK__Offerta__IdMater__29AC2CE0");

            entity.HasOne(d => d.IdResaNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdResa)
                .HasConstraintName("FK__Offerta__IdResa__3429BB53");

            entity.HasOne(d => d.IdStatoFarEastNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdStatoFarEast)
                .HasConstraintName("FK__Offerta__IdStato__54968AE5");

            entity.HasOne(d => d.IdTipoPagamentoNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdTipoPagamento)
                .HasConstraintName("FK__Offerta__IdTipoP__361203C5");

            entity.HasOne(d => d.IdTipoProdottoNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdTipoProdotto)
                .HasConstraintName("FK__Offerta__IdTipoP__28B808A7");

            entity.HasOne(d => d.IdTipoRigidoDfNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdTipoRigidoDf)
                .HasConstraintName("FK__Offerta__IdTipoR__53A266AC");

            entity.HasOne(d => d.IdTrasportatoreNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdTrasportatore)
                .HasConstraintName("FK__Offerta__IdTrasp__39E294A9");

            entity.HasOne(d => d.IdTrasportoNavigation).WithMany(p => p.OffertaIdTrasportoNavigation)
                .HasForeignKey(d => d.IdTrasporto)
                .HasConstraintName("FK__Offerta__IdTrasp__558AAF1E");

            entity.HasOne(d => d.IdTrasportoItaNavigation).WithMany(p => p.OffertaIdTrasportoItaNavigation)
                .HasForeignKey(d => d.IdTrasportoIta)
                .HasConstraintName("FK__Offerta__IdTrasp__52AE4273");

            entity.HasOne(d => d.IdValutaNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.IdValuta)
                .HasConstraintName("FK__Offerta__IdValut__7132C993");

            entity.HasOne(d => d.PelabileNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.Pelabile)
                .HasConstraintName("FK__Offerta__Pelabil__324172E1");

            entity.HasOne(d => d.SerigrafiaNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.Serigrafia)
                .HasConstraintName("FK__Offerta__Serigra__2F650636");

            entity.HasOne(d => d.SolderNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.Solder)
                .HasConstraintName("FK__Offerta__Solder__2C88998B");

            entity.HasOne(d => d.TendinaturaNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.Tendinatura)
                .HasConstraintName("FK__Offerta__Tendina__3335971A");

            entity.HasOne(d => d.TestElettricoNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.TestElettrico)
                .HasConstraintName("FK__Offerta__TestEle__2E70E1FD");

            entity.HasOne(d => d.TipoSolderNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.TipoSolder)
                .HasConstraintName("FK__Offerta__TipoSol__2D7CBDC4");
        });

        modelBuilder.Entity<OffertaMontaggio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OffertaM__3214EC0706CD04F7");

            entity.HasOne(d => d.IdOffertaNavigation).WithMany(p => p.OffertaMontaggio)
                .HasForeignKey(d => d.IdOfferta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offerta");
        });

        modelBuilder.Entity<OffertaRiga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OffertaR__3214EC07117F9D94");

            entity.Property(e => e.DataQuotazione).HasColumnType("datetime");
            entity.Property(e => e.FCinaAereo).HasColumnName("fCinaAereo");
            entity.Property(e => e.FCinaBlind).HasColumnName("fCinaBlind");
            entity.Property(e => e.FCinaFast).HasColumnName("fCinaFast");
            entity.Property(e => e.FCinaNave).HasColumnName("fCinaNave");
            entity.Property(e => e.FFobHk).HasColumnName("fFobHK");
            entity.Property(e => e.PrezzoDcmQeuro).HasColumnName("PrezzoDcmQEuro");
            entity.Property(e => e.PrezzoDcmQval).HasColumnName("PrezzoDcmQVal");

            entity.HasOne(d => d.IdOffertaNavigation).WithMany(p => p.OffertaRiga)
                .HasForeignKey(d => d.IdOfferta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OffertaRiga_Offerta");
        });

        modelBuilder.Entity<OffertaRigaFarEast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RigaFarE__3214EC070DAF0CB0");

            entity.Property(e => e.DataArrivo).HasColumnType("datetime");
            entity.Property(e => e.DataConfermaCliente).HasColumnType("datetime");
            entity.Property(e => e.DataConsegna).HasColumnType("datetime");
            entity.Property(e => e.DataPartenza).HasColumnType("datetime");

            entity.HasOne(d => d.IdFornitoreNavigation).WithMany(p => p.OffertaRigaFarEast)
                .HasForeignKey(d => d.IdFornitore)
                .HasConstraintName("FK_OffertaRigaFE_Fornitore");

            entity.HasOne(d => d.IdOffertaNavigation).WithMany(p => p.OffertaRigaFarEast)
                .HasForeignKey(d => d.IdOfferta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OffertaRigaFE_Offerta");

            entity.HasOne(d => d.IdTrasportatoreNavigation).WithMany(p => p.OffertaRigaFarEast)
                .HasForeignKey(d => d.IdTrasportatore)
                .HasConstraintName("FK_OffertaRigaFE_Trasportatore");

            entity.HasOne(d => d.IdTrasportoNavigation).WithMany(p => p.OffertaRigaFarEast)
                .HasForeignKey(d => d.IdTrasporto)
                .HasConstraintName("FK_OffertaRigaFE_Trasporto");
        });

        modelBuilder.Entity<Parametro>(entity =>
        {
            entity.HasKey(e => e.Codice).HasName("PK__Parametr__0636EC1C1332DBDC");

            entity.Property(e => e.Codice)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Valore)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pelabile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pelabile__3214EC075812160E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PelabileDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__Pelabile__39856828503BEA1C");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.PelabileDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pelabile_Desc");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.PelabileDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PelabileD__IdLin__1975C517");
        });

        modelBuilder.Entity<PostCalcolo>(entity =>
        {
            entity.HasKey(e => e.Nome).HasName("PK__PostCalc__7D8FE3B31AD3FDA4");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Formula)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PreCalcolo>(entity =>
        {
            entity.HasKey(e => e.Nome).HasName("PK__PreCalco__7D8FE3B317036CC0");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Formula)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Resa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resa__3214EC076B24EA82");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Codice)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Serigrafia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Serigraf__3214EC074CA06362");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SerigrafiaDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__Serigraf__39856828540C7B00");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.SerigrafiaDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Serigrafia_Desc");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.SerigrafiaDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Serigrafi__IdLin__1A69E950");
        });

        modelBuilder.Entity<Solder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solder__3214EC073E52440B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SolderDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__SolderDe__3985682857DD0BE4");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.SolderDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solder_Desc");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.SolderDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SolderDes__IdLin__1B5E0D89");
        });

        modelBuilder.Entity<SpessoreMateriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spessore__3214EC07267ABA7A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SpessoreRame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spessore__3214EC072A4B4B5E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatoFarEast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatoFar__3214EC07395884C4");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Strato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Strati__3214EC071ED998B2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tendinatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tendinat__3214EC075FB337D6");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TendinaturaDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__Tendinat__398568285BAD9CC8");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.TendinaturaDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tendinatura_Desc");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.TendinaturaDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tendinatu__IdLin__1C5231C2");
        });

        modelBuilder.Entity<TestElettrico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestElet__3214EC075441852A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TestElettricoDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__TestElet__398568285F7E2DAC");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.TestElettricoDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestElettrico_desc");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.TestElettricoDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestElett__IdLin__1D4655FB");
        });

        modelBuilder.Entity<TipoPagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPaga__3214EC0773BA3083");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoProdotto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoProd__3214EC072E1BDC42");

            entity.Property(e => e.CodicePerLayup)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PesoKgmetroQ).HasColumnName("PesoKGMetroQ");
        });

        modelBuilder.Entity<TipoRigido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoRigi__3214EC0731EC6D26");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoRigidoDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__TipoRigi__39856828634EBE90");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.TipoRigidoDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoRigido_desc");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.TipoRigidoDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoRigid__IdLin__1E3A7A34");
        });

        modelBuilder.Entity<TipoSolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoSold__3214EC0747DBAE45");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoSolderDesc>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdLingua }).HasName("PK__TipoSold__39856828671F4F74");

            entity.Property(e => e.Descrizione)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.TipoSolderDesc)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoSolder_desc");

            entity.HasOne(d => d.IdLinguaNavigation).WithMany(p => p.TipoSolderDesc)
                .HasForeignKey(d => d.IdLingua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoSolde__IdLin__1F2E9E6D");
        });

        modelBuilder.Entity<Trasportatore>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IndirizzoMail)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTrasportoNavigation).WithMany(p => p.Trasportatore)
                .HasForeignKey(d => d.IdTrasporto)
                .HasConstraintName("FK_Trasportatore_TRasporto");
        });

        modelBuilder.Entity<Trasporto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trasport__3214EC076383C8BA");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Codice)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCorrispondenteNavigation).WithMany(p => p.Trasporto)
                .HasForeignKey(d => d.IdCorrispondente)
                .HasConstraintName("FK_Trasport_Corrisp");
        });

        modelBuilder.Entity<Valuta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Valute__3214EC071B0907CE");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Codice)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DescrBreve)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descrizione)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DummyPoof)
                .HasMaxLength(98)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
