using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Uniban.GlassFileData.Proxies.Models
{
    public abstract class ProxyResponse<T>
    {
        protected readonly HttpResponseMessage httpResponseMessage;

        public ProxyResponse(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public bool IsSuccessStatusCode => httpResponseMessage.IsSuccessStatusCode;
        public HttpStatusCode StatusCode => httpResponseMessage.StatusCode;

        protected abstract Task<T> GetContentFromMessageAsync();

        public async Task<T> GetContentAsync(bool is404SuccessCode = false)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await GetContentFromMessageAsync();
            }

            if (is404SuccessCode && httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return default;
            }

            var errorContent = await httpResponseMessage.Content.ReadAsStringAsync();
            var errorMessage = $"Could not get a succesful answer from {httpResponseMessage.RequestMessage.RequestUri}."
                            + $" StatusCode: '{httpResponseMessage.StatusCode}'. Content: '{errorContent}'.";

            throw new HttpRequestException(errorMessage);
        }
    }
}
