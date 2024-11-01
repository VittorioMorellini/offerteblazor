using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Offerte.Utils;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;
using System.Data;

namespace OfferteWeb.Services;

public interface ITableService : IBaseService<GenericEntity, long, OfferteDbContext>, ISearchEntities<GenericEntity>, IUpdateEntities<GenericEntity>
{
    IEnumerable<GenericEntity> Search(GenericEntitySearchModel model);
}

public class TableService : BaseService<GenericEntity, long, OfferteDbContext>, ITableService
{
    public string TableName { get; set; }
    //public string PrimaryKeyName { get; set; }
    public string DescriptionName { get; set; }
    public TableService(IConfiguration configuration, OfferteDbContext ctx = null)
        : base(configuration, ctx)
    {
    }

    public IEnumerable<GenericEntity> Search(GenericEntitySearchModel model)
    {
        var list = new List<GenericEntity>();
        var conn = ctx.Database.GetDbConnection();

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            using var command = conn.CreateCommand();
            var qb = new QueryBuilder(model);
            qb.From($"{TableName} t");
            qb.Select(string.Join(", ", new string[] {
                        "t.[Id]",
                        $"t.[{DescriptionName}]"
                    }));


            qb = ApplyFilter(model, qb);
            qb.Create(command);

            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int i = 0;
                    var row = new GenericEntity
                    {
                        Id = reader.GetInt64(i++),
                        Descrizione = reader.GetNullableString(i++),
                    };
                    list.Add(row);
                }
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }

        return list;
    }

    public IEnumerable<GenericEntity> SearchAll(bool includeDeleted, QueryBuilderSearchModel searchModel)
    {
        var list = new List<GenericEntity>();
        var conn = ctx.Database.GetDbConnection();

        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            using var command = conn.CreateCommand();
            var qb = new QueryBuilder();
            qb.From($"{TableName} t");
            qb.Select(string.Join(", ", new string[] {
                        "t.[Id]",
                        $"t.[{DescriptionName}]"
                    }));

            qb.Create(command);
            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int i = 0;
                    var row = new GenericEntity
                    {
                        Id = reader.GetInt64(i++),
                        Descrizione = reader.GetNullableString(i++),
                    };
                    list.Add(row);
                }
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
        return list;
    }

    private QueryBuilder ApplyFilter(GenericEntitySearchModel model, QueryBuilder qb = null)
    {
        qb = qb ?? new QueryBuilder(model);

        qb.AddPredicate(model, x => x.Id, $"d.Id");
        qb.AddPredicate(model, x => x.Descrizione, $"d.{DescriptionName}");
        qb.OrderBy($"d.{DescriptionName} DESC");

        return qb;
    }
    
    public IEnumerable<GenericEntity> SearchByString(string searchString, QueryBuilderSearchModel searchModel, bool includeDeleted)
    {
        //throw new NotImplementedException();
        GenericEntitySearchModel model = new();
        model.Descrizione = searchString;
        return Search(model);
    }
    public Task<bool> Delete(GenericEntity? item)
    {
        var result = base.Delete(item.Id);
        return Task.FromResult(result);
    }

    public Task<long?> Add(GenericEntity? item)
    {
        var result = base.Save(0, item);
        if (result != null)
            return Task.FromResult((long?)result.Id);
        else
            return null;
    }

    public Task<GenericEntity> Update(GenericEntity? item)
    {
        base.Save(item.Id, item);
        return Task.FromResult(item);
    }
}
