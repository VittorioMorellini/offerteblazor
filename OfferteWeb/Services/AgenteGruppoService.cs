using System;
using Microsoft.Extensions.Configuration;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Services
{
    public interface IAgenteGruppoService : IBaseService<AgenteGruppo, long, OfferteDbContext>
    {
        IEnumerable<AgenteGruppo> Search(AgenteGruppoSearchModel model);
    }

    public class AgenteGruppoService : BaseService<AgenteGruppo, long, OfferteDbContext>, IAgenteGruppoService
    {
        public AgenteGruppoService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }

        public IEnumerable<AgenteGruppo> Search(AgenteGruppoSearchModel model)
        {
            return ctx.AgenteGruppo;
        }
    }

    public class AgenteGruppoSearchModel : QueryBuilderSearchModel
    {

    }
}
