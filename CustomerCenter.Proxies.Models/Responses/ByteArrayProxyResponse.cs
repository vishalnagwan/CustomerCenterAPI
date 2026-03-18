using System.Net.Http;
using System.Threading.Tasks;

namespace Uniban.GlassFileData.Proxies.Models.Responses
{
    internal class ByteArrayProxyResponse : ProxyResponse<byte[]>
    {
        public ByteArrayProxyResponse(HttpResponseMessage httpResponseMessage)
            : base(httpResponseMessage)
        {
        }

        protected override Task<byte[]> GetContentFromMessageAsync()
        {
            return httpResponseMessage.Content.ReadAsByteArrayAsync();
        }
    }
}
