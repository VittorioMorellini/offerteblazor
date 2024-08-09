using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;
using static OfferteWeb.Services.TipoProdottoService;

namespace OfferteWeb.Services
{
    public interface ITipoProdottoService : IBaseService<TipoProdotto, long, OfferteDbContext>, ISearchEntities<TipoProdotto>, IUpdateEntities<TipoProdotto>
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

        public IEnumerable<TipoProdotto> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            return ctx.TipoProdotto.ToList();
        }

        public IEnumerable<TipoProdotto> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            //throw new NotImplementedException();
            IQueryable<TipoProdotto> tipiProdottis = ctx.TipoProdotto.AsNoTracking();            
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                tipiProdottis = tipiProdottis.Where(x => x.Descrizione != null && x.Descrizione.Contains(searchString));
            }
            return tipiProdottis.OrderByDescending(x => x.Descrizione).ToList();
        }
        public Task<bool> Delete(TipoProdotto? item)
        {
            var result = base.Delete(item.Id);
            return Task.FromResult(result);
        }

        public Task<long?> Add(TipoProdotto? item)
        {
            var result = base.Save(0, item);
            if (result != null)
                return Task.FromResult((long?)result.Id);
            else
                return null;
        }

        public Task<TipoProdotto> Update(TipoProdotto? item)
        {
            base.Save(item.Id, item);
            return Task.FromResult(item);
        }
    }
    public class TipoProdottoSearchModel : QueryBuilderSearchModel
    {
        public string Text { get; set; }
        public bool? Scadenzario { get; set; }
        public bool? Faq { get; set; }
        public bool? Manuali { get; set; }
        public bool? Quesiti { get; set; }
    }
}
