using Microsoft.Extensions.Options;

namespace Uniban.GlassFileData.Proxies.DI
{
    internal class PhoenixDelegatingHandler : BearerDelegatingHandler
    {
        private const string Scope = "Phoenix_API";
        public PhoenixDelegatingHandler(IOptions<ProxyAuthenticationOptions> options) : base(options, Scope)
        {
        }
    }
}