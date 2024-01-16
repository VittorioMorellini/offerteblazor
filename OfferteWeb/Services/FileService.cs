using Microsoft.JSInterop;
namespace OfferteWeb.Services
{
    public interface IFileService
    {
        Task SaveAsAsync(IJSRuntime js, string filename, byte[] data);

    }

    public class FileService : IFileService
    {
        public async Task SaveAsAsync(IJSRuntime js, string filename, byte[] data)
        {
            await js.InvokeAsync<object>("saveAsFile", filename, Convert.ToBase64String(data));
        }
    }
}
