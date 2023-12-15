using Microsoft.EntityFrameworkCore;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Data
{
    public class ContextService
    {
        protected OfferteDbContext context;        

        public ContextService(OfferteDbContext context)
        {
            this.context = context;
        }
        public void RestoreItem(Object item)
        {
            context.Entry(item).State = EntityState.Unchanged;
        }

        //public void SaveChanges()
        //{
        //    context.SaveChanges();
        //}

        public string GetLog()
        {
            context.ChangeTracker.DetectChanges();
            return context.ChangeTracker.DebugView.LongView;
        }
    }

    public interface ISearchEntities<T>
    {
        public IEnumerable<T> SearchByString(string searchString, QueryBuilderSearchModel model, bool includeDeleted);
        public IEnumerable<T> SearchAll(bool includeDeleted, QueryBuilderSearchModel model);
        //public T Find(long id);
        //public Task<bool> Delete(T? item);
        //public Task<long?> Add(T? item);
        //public Task<bool> Update(T? item);
    }
}
