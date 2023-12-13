using System;
using System.Collections.Generic;

namespace OfferteWeb.Models;

public partial class Lingua
{
    public long Id { get; set; }

    public string? Descrizione { get; set; }

    public virtual ICollection<ColoreSerigrafiaDesc> ColoreSerigrafiaDesc { get; set; } = new List<ColoreSerigrafiaDesc>();

    public virtual ICollection<FinituraMeccanicaDesc> FinituraMeccanicaDesc { get; set; } = new List<FinituraMeccanicaDesc>();

    public virtual ICollection<FinituraSuperficialeDesc> FinituraSuperficialeDesc { get; set; } = new List<FinituraSuperficialeDesc>();

    public virtual ICollection<GrafiteDesc> GrafiteDesc { get; set; } = new List<GrafiteDesc>();

    public virtual ICollection<Label> Label { get; set; } = new List<Label>();

    public virtual ICollection<Offerta> Offerta { get; set; } = new List<Offerta>();

    public virtual ICollection<PelabileDesc> PelabileDesc { get; set; } = new List<PelabileDesc>();

    public virtual ICollection<SerigrafiaDesc> SerigrafiaDesc { get; set; } = new List<SerigrafiaDesc>();

    public virtual ICollection<SolderDesc> SolderDesc { get; set; } = new List<SolderDesc>();

    public virtual ICollection<TendinaturaDesc> TendinaturaDesc { get; set; } = new List<TendinaturaDesc>();

    public virtual ICollection<TestElettricoDesc> TestElettricoDesc { get; set; } = new List<TestElettricoDesc>();

    public virtual ICollection<TipoRigidoDesc> TipoRigidoDesc { get; set; } = new List<TipoRigidoDesc>();

    public virtual ICollection<TipoSolderDesc> TipoSolderDesc { get; set; } = new List<TipoSolderDesc>();
}
