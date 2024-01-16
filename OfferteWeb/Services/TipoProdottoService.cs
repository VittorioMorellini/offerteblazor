using System;
using Microsoft.Extensions.Configuration;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;
using static OfferteWeb.Services.TipoProdottoService;

namespace OfferteWeb.Services
{
    public interface ITipoProdottoService : IBaseService<TipoProdotto, long, OfferteDbContext>, ISearchEntities<TipoProdotto>
    {
        IEnumerable<TipoProdotto> Search(TipoProdottoSearchModel model);
    }

    public class TipoProdottoService : BaseService<TipoProdotto, long, OfferteDbContext>, ITipoProdottoService
    {
        public TipoProdottoService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }

        public IEnumerable<TipoProdotto> Search(TipoProdottoSearchModel model)
        {
            return ctx.TipoProdotto;
        }
        public class TipoProdottoSearchModel : QueryBuilderSearchModel
        {
            public string Text { get; set; }
            public bool? Scadenzario { get; set; }
            public bool? Faq { get; set; }
            public bool? Manuali { get; set; }
            public bool? Quesiti { get; set; }
        }

        public IEnumerable<TipoProdotto> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoProdotto> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            throw new NotImplementedException();
        }
    }

}
