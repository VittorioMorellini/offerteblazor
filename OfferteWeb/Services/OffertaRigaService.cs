using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Services
{
    public interface IOffertaRigaService : IBaseService<OffertaRiga, long, OfferteDbContext>, ISearchEntities<OffertaRiga>, IUpdateEntities<OffertaRiga>
    {
        Tuple<IEnumerable<OffertaRiga>, int> SearchPaged(OffertaRigaSearchModel model, bool includeDeleted);
    }

    public class OffertaRigaService : BaseService<OffertaRiga, long, OfferteDbContext>, IOffertaRigaService
    {
        public OffertaRigaService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }


        private Tuple<IEnumerable<OffertaRiga>, int> _search(OffertaRigaSearchModel model)
        {
            int count = 0;
            IQueryable<OffertaRiga> offerteRiga = ctx.OffertaRiga
                .AsNoTracking()
                .Where(x => (model.IncludeDeleted == null || model.IncludeDeleted == true))
                .OrderByDescending(x => x.DataQuotazione)
                .Select(x => new OffertaRiga
                {
                    Id = x.Id,
                    Quantita = x.Quantita,
                    GiorniDiConsegna = x.GiorniDiConsegna,
                    IdOfferta = x.IdOfferta,
                    DataQuotazione = x.DataQuotazione,
                    Campione = x.Campione,
                });

            if (model != null)
            {
                if (model.Id.HasValue)
                {
                    offerteRiga = offerteRiga.Where(x => x.Id == model.Id);
                }
                if (model.IdOfferta.HasValue)
                {
                    offerteRiga = offerteRiga.Where(x => x.IdOfferta == model.IdOfferta);
                }
                if (!model.DateFrom.HasValue)
                {
                    var sqlMin = System.Data.SqlTypes.SqlDateTime.MinValue;
                    model.DateFrom = new DateTime(sqlMin.Value.Year, sqlMin.Value.Month, sqlMin.Value.Day);
                    offerteRiga = offerteRiga.Where(x => x.DataQuotazione >= model.DateFrom);
                }
                if (!model.DateTo.HasValue)
                {
                    var sqlMax = System.Data.SqlTypes.SqlDateTime.MaxValue;
                    model.DateTo = new DateTime(sqlMax.Value.Year, sqlMax.Value.Month, sqlMax.Value.Day);
                    offerteRiga = offerteRiga.Where(x => x.DataQuotazione <= model.DateTo);
                }
            }
            if ((bool)model?.Limit.HasValue)
            {
                offerteRiga = offerteRiga.Take(model.Limit.Value);
            }

            count = offerteRiga.Count();
            //if (model.Pager != null)
            //{
            //    offerte = offerte.Skip(model.Pager.Skip.Value).Take(model.Pager.Take.Value);
            //}
            return new Tuple<IEnumerable<OffertaRiga>, int>(offerteRiga, count);
        }


        public IEnumerable<OffertaRiga> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OffertaRiga> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            throw new NotImplementedException();
        }
        public Tuple<IEnumerable<OffertaRiga>, int> SearchPaged(OffertaRigaSearchModel model, bool includeDeleted)
        {
            return _search(model);
        }

        public Task<bool> Delete(OffertaRiga? item)
        {
            var result = base.Delete(item.Id);
            return Task.FromResult(result);
        }

        public Task<long?> Add(OffertaRiga? item)
        {
            var result = base.Save(0, item);
            if (result != null)
                return Task.FromResult((long?)result.Id);
            else
                return null;
        }

        public Task<OffertaRiga> Update(OffertaRiga? item)
        {
            base.Save(item.Id, item);

            return Task.FromResult(item);
        }
    }

    public class OffertaRigaSearchModel : QueryBuilderSearchModel
    {
        public long? IdOfferta { get; set; }
        public long? IdAgente { get; set; }
        public long? IdCliente { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
