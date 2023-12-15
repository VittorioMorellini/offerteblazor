using OfferteWeb.Models;
using System.Reflection;
using static OfferteWeb.Services.TipoProdottoService;

namespace OfferteWeb.Services
{
    public class SearchModelStore
    {
        public OffertaSearchModel OffertaModel { get; private set; }
        public TipoProdottoSearchModel TipoProdottoModel { get; private set; }
        public AgenteSearchModel AgenteModel { get; private set; }

        public T GetModel<T>()
        {
            var model = (T)GetType().GetProperties().First(x => x.PropertyType == typeof(T)).GetValue(this);
            if (model is not null)
            {
                return model;
            }
            return CreateModel<T>();
        }

        public void SaveModel<T>(T model)
        {
            GetType().GetProperties().First(x => x.PropertyType == typeof(T)).SetValue(this, model);
        }

        public void ClearModel<T>()
        {
            GetType().GetProperties().First(x => x.PropertyType == typeof(T)).SetValue(this, null);
        }

        public T CreateModel<T>()
        {
            var inst = Activator.CreateInstance<T>();
            SaveModel<T>(inst);
            return inst;
        }
    }
}
