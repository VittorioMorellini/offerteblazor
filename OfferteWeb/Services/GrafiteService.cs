using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;
using static OfferteWeb.Services.GrafiteService;

namespace OfferteWeb.Services
{
    public interface IGrafiteService : IBaseService<Grafite, long, OfferteDbContext>, ISearchEntities<Grafite>, IUpdateEntities<Grafite>
    {
        IEnumerable<Grafite> Search(GrafiteSearchModel model);
    }

    public class GrafiteService : BaseService<Grafite, long, OfferteDbContext>, IGrafiteService
    {
        public GrafiteService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }

        public IEnumerable<Grafite> Search(GrafiteSearchModel model)
        {
            return ctx.Grafite;
        }

        public IEnumerable<Grafite> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            return ctx.Grafite.ToList();
        }

        public IEnumerable<Grafite> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            //throw new NotImplementedException();
            IQueryable<Grafite> tipiProdottis = ctx.Grafite.AsNoTracking();            
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                tipiProdottis = tipiProdottis.Where(x => x.Descrizione != null && x.Descrizione.Contains(searchString));
            }
            return tipiProdottis.OrderByDescending(x => x.Descrizione).ToList();
        }
        public Task<bool> Delete(Grafite? item)
        {
            var result = base.Delete(item.Id);
            return Task.FromResult(result);
        }

        public Task<long?> Add(Grafite? item)
        {
            var result = base.Save(0, item);
            if (result != null)
                return Task.FromResult((long?)result.Id);
            else
                return null;
        }

        public Task<Grafite> Update(Grafite? item)
        {
            base.Save(item.Id, item);
            return Task.FromResult(item);
        }
    }
    public class GrafiteSearchModel : QueryBuilderSearchModel
    {
        public string Descrizione { get; set; }
    }
}
