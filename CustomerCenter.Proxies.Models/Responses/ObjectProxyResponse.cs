using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Uniban.GlassFileData.Proxies.Models.Responses
{
    internal class ObjectProxyResponse<T> : ProxyResponse<T>
        where T : class
    {
        public ObjectProxyResponse(HttpResponseMessage httpResponseMessage)
            : base(httpResponseMessage)
        {
        }

        protected override async Task<T> GetContentFromMessageAsync()
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }


    }
}
