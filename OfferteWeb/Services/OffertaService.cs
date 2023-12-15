using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Services
{
    public interface IOffertaService : IBaseService<Offerta, long, OfferteDbContext>, ISearchEntities<Offerta>
    {
        Tuple<IEnumerable<Offerta>, int> SearchPaged(OffertaSearchModel model, bool includeDeleted);
    }

    public class OffertaService : BaseService<Offerta, long, OfferteDbContext>, IOffertaService
    {
        public OffertaService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }

        internal IEnumerable<Offerta> Search(OffertaSearchModel model)
        {
            return _search(model).Item1;
        }


        private Tuple<IEnumerable<Offerta>, int> _search(OffertaSearchModel model)
        {
            int count = 0;
            IQueryable<Offerta> offerte = ctx.Offerta
                .AsNoTracking()
                .Where(x => (model.IncludeDeleted == null || model.IncludeDeleted == true))
                .OrderByDescending(x => x.DataOfferta)
                .Select(x => new Offerta
                {
                    Id = x.Id,
                    CodiceInterno = x.CodiceInterno,
                    IdTipoProdotto = x.IdTipoProdotto,
                    IdAgente = x.IdAgente,
                    DataOfferta = x.DataOfferta,
                });

            if (model != null)
            {
                if (model.Id.HasValue)
                {
                    offerte = offerte.Where(x => x.Id == model.Id);
                }
                if (!model.DateFrom.HasValue)
                {
                    var sqlMin = System.Data.SqlTypes.SqlDateTime.MinValue;
                    model.DateFrom = new DateTime(sqlMin.Value.Year, sqlMin.Value.Month, sqlMin.Value.Day);
                }
                if (!model.DateTo.HasValue)
                {
                    var sqlMax = System.Data.SqlTypes.SqlDateTime.MaxValue;
                    model.DateTo = new DateTime(sqlMax.Value.Year, sqlMax.Value.Month, sqlMax.Value.Day);
                }
            }
            if (!string.IsNullOrWhiteSpace(model.Pager?.OrderBy))
            {
                //if (model.Pager.Direction == MudBlazor.SortDirection.Ascending)
                //{
                //    offerte = offerte.OrderBy(model.Pager.OrderBy);
                //}
                //else
                //{
                //    offerte = offerte.OrderByDescending(model.Pager.OrderBy);
                //}
            }
            else
            {
                offerte = offerte.OrderByDescending(x => x.DataOfferta);
            }
            if ((bool)model?.Limit.HasValue)
            {
                offerte = offerte.Take(model.Limit.Value);
            }

            count = offerte.Count();
            if (model.Pager != null)
            {
                offerte = offerte.Skip(model.Pager.Skip.Value).Take(model.Pager.Take.Value);
            }

            return new Tuple<IEnumerable<Offerta>, int>(offerte, count);
        }


        public IEnumerable<Offerta> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offerta> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            throw new NotImplementedException();
        }
        public Tuple<IEnumerable<Offerta>, int> SearchPaged(OffertaSearchModel model, bool includeDeleted)
        {
            return _search(model);
        }
    }

    public class OffertaSearchModel : QueryBuilderSearchModel
    {
        public string CodiceInterno { get; set; }
        public string Stato { get; set; }
        public string Tag { get; set; }
        public long? PostType { get; set; }
        public long? IdTipoProdotto { get; set; }
        public long? IdAgente { get; set; }
        public long? IdCliente { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
