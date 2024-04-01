using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Services
{
    public interface ICirComService : IBaseService<CirCom, long, OfferteDbContext>, ISearchEntities<CirCom>
    {
        Tuple<IEnumerable<CirCom>, int> SearchPaged(CirComSearchModel model, bool includeDeleted);

        Task<CirCom> FindAsync(string codiceInterno);
    }

    public class CirComService : BaseService<CirCom, long, OfferteDbContext>, ICirComService
    {
        public CirComService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }

        internal IEnumerable<CirCom> Search(CirComSearchModel model)
        {
            return _search(model).Item1;
        }

        public async Task<CirCom> FindAsync(string codiceInterno)
        {
            if (!string.IsNullOrWhiteSpace(codiceInterno))
                return await ctx.CirCom.Where(x => x.CodiceInterno == codiceInterno).FirstOrDefaultAsync();
            else
                return null;
        }

        private Tuple<IEnumerable<CirCom>, int> _search(CirComSearchModel model)
        {
            int count = 0;
            IQueryable<CirCom> circuiti = ctx.CirCom
                .AsNoTracking()
                .Where(x => (model.IncludeDeleted == null || model.IncludeDeleted == true));
                //.OrderByDescending(x => x.RagioneSociale)

            if (model != null)
            {
                if (model.Id.HasValue)
                {
                    circuiti = circuiti.Where(x => x.CodiceEdp == model.Id);
                }
                if (!string.IsNullOrWhiteSpace(model.CodiceInterno))
                {
                    circuiti = circuiti.Where(x => x.CodiceInterno != null && x.CodiceInterno.Contains(model.CodiceInterno));
                }
            }
            if ((bool)model?.Limit.HasValue)
            {
                circuiti = circuiti.Take(model.Limit.Value);
            }

            if (model.Pager != null)
            {
                circuiti = circuiti.Skip(model.Pager.Skip.Value).Take(model.Pager.Take.Value);
            }
            if (!string.IsNullOrWhiteSpace(model.Pager?.OrderBy))
            {
                //if (model.Pager.Direction == MudBlazor.SortDirection.Ascending)
                //{
                //    offerte = offerte.OrderBy(model.Pager.OrderBy);
                //}
            }
            else
            {
                circuiti = circuiti.OrderByDescending(x => x.CodiceInterno);
            }
            circuiti = circuiti.Select(x => new CirCom
            {
                CodiceEdp = x.CodiceEdp,
                CodiceInterno = x.CodiceInterno,
                CodiceCliente = x.CodiceCliente,
                //Cap = x.Cap,
                //Localita = x.Localita
            });
            count = circuiti.Count();

            return new Tuple<IEnumerable<CirCom>, int>(circuiti, count);
        }


        public IEnumerable<CirCom> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CirCom> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            throw new NotImplementedException();
        }
        public Tuple<IEnumerable<CirCom>, int> SearchPaged(CirComSearchModel model, bool includeDeleted)
        {
            return _search(model);
        }

        //public Task<bool> Delete(CirCom? item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<long?> Add(CirCom? item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> Update(CirCom? item)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class CirComSearchModel : QueryBuilderSearchModel
    {
        public long? Id { get; set; }
        public string CodiceInterno { get; set; }
    }
}
