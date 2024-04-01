using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Services
{
    public interface IGenericEntityService : IBaseService<GenericEntity, long, OfferteDbContext>, ISearchEntities<GenericEntity>
    {
        string TableName { get; set; }
        Tuple<IEnumerable<GenericEntity>, int> SearchPaged(GenericEntitySearchModel model, bool includeDeleted);

        Task<GenericEntity> FindAsync(long id);
    }

    public class GenericEntityService : BaseService<GenericEntity, long, OfferteDbContext>, IGenericEntityService
    {
        public string TableName { get;  set; }
        public GenericEntityService(IConfiguration configuration, OfferteDbContext ctx = null)
            : base(configuration, ctx)
        {
        }

        internal IEnumerable<GenericEntity> Search(GenericEntitySearchModel model)
        {
            return _search(model).Item1;
        }

        public async Task<GenericEntity> FindAsync(long id)
        {
            var connection = new SqlConnection(ctx.Database.GetConnectionString());
            connection.Open();

            var s = "SELECT Id, Descrizione FROM " + TableName;
            if (id != 0)
            {
                s += " WHERE Id = @id";
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = s;
                command.Parameters.Add(new SqlParameter("id", id));
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    reader.Read();
                    var entity = new GenericEntity
                    {
                        Id = reader.GetInt64(i++),
                        // Codice = reader.GetString(i++),
                        Descrizione = reader.GetString(i++),
                    };
                    return entity;
                }
                return null;
            }
            else
                return null;
        }

        private Tuple<IEnumerable<GenericEntity>, int> _search(GenericEntitySearchModel model)
        {
            int count = 0;
            var connection = new SqlConnection(ctx.Database.GetConnectionString());
            connection.Open();
            List<GenericEntity> entities = new();
            List<SqlParameter> parameters = new();

            var s = "SELECT Id, Descrizione FROM " + TableName;
            s += " WHERE 1=1";
            if (model != null)
            {
                if (model.Id.HasValue)
                {
                    s += " AND Id = @id";
                    parameters.Add(new SqlParameter("id", model.Id));
                }
                if (!string.IsNullOrWhiteSpace(model.Descrizione))
                {
                    s += " AND Descrizione LIKE @descrizione";
                    parameters.Add(new SqlParameter("descrizione", model.Descrizione));
                }
            }
            //if ((bool)model?.Limit.HasValue)
            //{
            //    entities = entities.Take(model.Limit.Value);
            //}
            //if (model.Pager != null)
            //{
            //    entities = entities.Skip(model.Pager.Skip.Value).Take(model.Pager.Take.Value);
            //}
            if (!string.IsNullOrWhiteSpace(model.Pager?.OrderBy))
            {
                //if (model.Pager.Direction == MudBlazor.SortDirection.Ascending)
                //{
                //    offerte = offerte.OrderBy(model.Pager.OrderBy);
                //}
            }
            else
            {
                s += " ORDER BY Descrizione";
            }
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = s;
            if (parameters.Count > 0)
                command.Parameters.Add(parameters);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int i = 0;
                    var entity = new GenericEntity
                    {
                        Id = reader.GetInt64(i++),
                        //Codice = reader.GetString(i++),
                        Descrizione = reader.GetString(i++),
                    };
                    entities.Add(entity);
                }
            }            
            count = entities.Count();
            return new Tuple<IEnumerable<GenericEntity>, int>(entities, count);
        }


        public IEnumerable<GenericEntity> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GenericEntity> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
        {
            throw new NotImplementedException();
        }
        public Tuple<IEnumerable<GenericEntity>, int> SearchPaged(GenericEntitySearchModel model, bool includeDeleted)
        {
            return _search(model);
        }

        //public Task<bool> Delete(GenericEntity? item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<long?> Add(GenericEntity? item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> Update(GenericEntity? item)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class GenericEntitySearchModel : QueryBuilderSearchModel
    {
        public long? Id { get; set; }
        public string CodiceInterno { get; set; }
        public string Descrizione { get; set; }
    }
}
