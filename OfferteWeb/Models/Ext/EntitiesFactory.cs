using OfferteWeb.State;
using System.Reflection;

namespace OfferteWeb.Models
{
    public class EntitiesFactory
    {
        private AppState state { get; set; }
        public EntitiesFactory(AppState state)
        {
            this.state = state;
        }

        public T? Create<T>()
        {
            T? inst = (T?)Activator.CreateInstance(typeof(T));
            inst?.GetType().GetProperty("InsertUser")?.SetValue(inst, state.Username);
            inst?.GetType().GetProperty("UpdateUser")?.SetValue(inst, state.Username);
            inst?.GetType().GetProperty("InsertDate")?.SetValue(inst, DateTime.Now);
            inst?.GetType().GetProperty("UpdateDate")?.SetValue(inst, DateTime.Now);
            return inst;
        }
    }
}
