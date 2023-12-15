using Microsoft.AspNetCore.Components;
using OfferteWeb.Data;
using OfferteWeb.Models;
using OfferteWeb.Utils;

namespace OfferteWeb.Pages;
public class BaseListPage<T> : LayoutComponentBase
{
    [Inject]
    NavigationManager? NavManager { get; set; }

    //[Inject]
    //protected AppState State { get; set; }

    protected ISearchEntities<T>? searchService;
    public IEnumerable<T>? Items { get; set; }
    public string EntityName { get { return typeof(T).Name.ToLower(); } }

    public bool IsLoading { get; protected set; }

    internal async Task SetLoading(bool loading)
    {
        this.IsLoading = loading;
        await Task.Yield();
    }
    protected void SearchAll(QueryBuilderSearchModel model = null)
    {
        if (searchService != null)
        {
            Items = searchService.SearchAll(true, model);
            StateHasChanged();
        }
    }

    protected void SearchByString(string searchString, QueryBuilderSearchModel model = null)
    {
        if (searchService != null)
        {
            Items = searchService.SearchByString(searchString, model, true);
        }
    }

    protected void EditItem(long id)
    {
        if (NavManager != null)
            NavManager.NavigateTo($"/{EntityName}/edit/{id}");
    }

    protected void NewItem()
    {
        if (NavManager != null)
            NavManager.NavigateTo($"/{EntityName}/new");
    }
}
