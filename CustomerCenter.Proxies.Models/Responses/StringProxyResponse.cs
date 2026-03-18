using System.Net.Http;
using System.Threading.Tasks;

namespace Uniban.GlassFileData.Proxies.Models.Responses
{
    internal class StringProxyResponse : ProxyResponse<string>
    {
        public StringProxyResponse(HttpResponseMessage httpResponseMessage)
            : base(httpResponseMessage)
        {
        }

        protected override Task<string> GetContentFromMessageAsync()
        {
            return httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
