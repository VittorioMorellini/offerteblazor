using Microsoft.EntityFrameworkCore;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Services
{
    public interface IValutaService : IBaseService<Valuta, long, OfferteDbContext>, ISearchEntities<Valuta>, IUpdateEntities<Valuta>
    {
        IEnumerable<Valuta> Search(ValutaSearchModel model);
    }

    public class ValutaService : BaseService<Valuta, long, OfferteDbContext>, IValutaService
    {
        public ValutaService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }

        public IEnumerable<Valuta> Search(ValutaSearchModel model)
        {
            return ctx.Valuta;
        }

        public IEnumerable<Valuta> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            return ctx.Valuta.ToList();
        }

        public IEnumerable<Valuta> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            //throw new NotImplementedException();
            IQueryable<Valuta> valutas = ctx.Valuta.AsNoTracking();            
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                valutas = valutas.Where(x => x.Descrizione != null && x.Descrizione.Contains(searchString));
            }
            return valutas.OrderByDescending(x => x.Descrizione).ToList();
        }
        public Task<bool> Delete(Valuta? item)
        {
            var result = base.Delete(item.Id);
            return Task.FromResult(result);
        }

        public Task<long?> Add(Valuta? item)
        {
            var result = base.Save(0, item);
            if (result != null)
                return Task.FromResult((long?)result.Id);
            else
                return null;
        }

        public Task<Valuta> Update(Valuta? item)
        {
            base.Save(item.Id, item);
            return Task.FromResult(item);
        }
    }
    public class ValutaSearchModel : QueryBuilderSearchModel
    {
        public string Descrizione { get; set; }
    }
}
