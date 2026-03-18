using System.Net.Http;
using System.Threading.Tasks;
using Uniban.GlassFileData.Proxies.Models.Responses;

namespace Uniban.GlassFileData.Proxies.Models
{
    public static class ProxyResponseExtensions
    {
        public static async Task<ProxyResponse<byte[]>> GetByteArrayProxyResponseAsync(this Task<HttpResponseMessage> httpResponseMessageTask)
        {
            var httpResponseMessage = await httpResponseMessageTask;
            return httpResponseMessage.GetByteArrayProxyResponse();
        }

        public static ProxyResponse<byte[]> GetByteArrayProxyResponse(this HttpResponseMessage httpResponseMessage)
        {
            return new ByteArrayProxyResponse(httpResponseMessage);
        }

        public static async Task<ProxyResponse<T>> GetProxyResponseAsync<T>(this Task<HttpResponseMessage> httpResponseMessageTask)
            where T : class
        {
            var httpResponseMessage = await httpResponseMessageTask;
            return httpResponseMessage.GetProxyResponse<T>();
        }

        public static ProxyResponse<T> GetProxyResponse<T>(this HttpResponseMessage httpResponseMessage)
            where T : class
        {
            return new ObjectProxyResponse<T>(httpResponseMessage);
        }

        public static async Task<ProxyResponse<string>> GetStringProxyResponseAsync(this Task<HttpResponseMessage> httpResponseMessageTask)
        {
            var httpResponseMessage = await httpResponseMessageTask;
            return httpResponseMessage.GetStringProxyResponse();
        }

        public static ProxyResponse<string> GetStringProxyResponse(this HttpResponseMessage httpResponseMessage)
        {
            return new StringProxyResponse(httpResponseMessage);
        }
    }
}
