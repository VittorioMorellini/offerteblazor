using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Services
{
    public interface ICliComService : IBaseService<CliCom, int, OfferteDbContext>, ISearchEntities<CliCom>
    {
        Tuple<IEnumerable<CliCom>, int> SearchPaged(CliComSearchModel model, bool includeDeleted);

        Task<CliCom> FindAsync(int idCliente);
    }

    public class CliComService : BaseService<CliCom, int, OfferteDbContext>, ICliComService
    {
        public CliComService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }

        internal IEnumerable<CliCom> Search(CliComSearchModel model)
        {
            return _search(model).Item1;
        }

        public CliCom Find(long id)
        {
            throw new Exception("Not implemented");
        }

        public async Task<CliCom> FindAsync(int id)
        {
            return await ctx.CliCom.FindAsync(id);
        }

        private Tuple<IEnumerable<CliCom>, int> _search(CliComSearchModel model)
        {
            int count = 0;
            IQueryable<CliCom> clienti = ctx.CliCom
                .AsNoTracking()
                .Where(x => (model.IncludeDeleted == null || model.IncludeDeleted == true));
                //.OrderByDescending(x => x.RagioneSociale)

            if (model != null)
            {
                if (model.Id.HasValue)
                {
                    clienti = clienti.Where(x => x.Id == model.Id);
                }
                if (!string.IsNullOrWhiteSpace(model.RagioneSociale))
                {
                    clienti = clienti.Where(x => x.RagioneSociale != null && x.RagioneSociale.Contains(model.RagioneSociale));
                }
            }
            if ((bool)model?.Limit.HasValue)
            {
                clienti = clienti.Take(model.Limit.Value);
            }

            if (model.Pager != null)
            {
                clienti = clienti.Skip(model.Pager.Skip.Value).Take(model.Pager.Take.Value);
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
                clienti = clienti.OrderByDescending(x => x.RagioneSociale);
            }
            clienti = clienti.Select(x => new CliCom
            {
                Id = x.Id,
                RagioneSociale = x.RagioneSociale,
                Indirizzo = x.Indirizzo,
                Cap = x.Cap,
                Localita = x.Localita
            });

            count = clienti.Count();

            return new Tuple<IEnumerable<CliCom>, int>(clienti, count);
        }


        public IEnumerable<CliCom> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CliCom> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            throw new NotImplementedException();
        }
        public Tuple<IEnumerable<CliCom>, int> SearchPaged(CliComSearchModel model, bool includeDeleted)
        {
            return _search(model);
        }

        //public Task<bool> Delete(CliCom? item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<long?> Add(CliCom? item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> Update(CliCom? item)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class CliComSearchModel : QueryBuilderSearchModel
    {
        public string RagioneSociale { get; set; }
    }
}
