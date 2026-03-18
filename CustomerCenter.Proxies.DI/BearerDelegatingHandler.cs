using IdentityModel.Client;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Uniban.GlassFileData.Proxies.DI
{
    internal class BearerDelegatingHandler : DelegatingHandler
    {
        private readonly ProxyAuthenticationOptions options;
        private readonly string scope;

        public BearerDelegatingHandler(IOptions<ProxyAuthenticationOptions> options, string scope)
        {
            this.options = options.Value;
            this.scope = scope;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await GetTokenAsync();
            request.SetBearerToken(token);
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> GetTokenAsync()
        {
            var httpClient = new HttpClient();
            var discoveryRequest = new DiscoveryDocumentRequest
            {
                Address = options.Authority,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            };
            var disco = await httpClient.GetDiscoveryDocumentAsync(discoveryRequest);
            if (disco.IsError)
            {
                throw new Exception($"An error occured while trying to get discovery document for {options.Authority}: {disco.Error}.", disco.Exception);
            }
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = options.ClientId,
                ClientSecret = options.ClientSecret,
                Scope = scope
            });
            if (tokenResponse.IsError)
            {
                throw new Exception($"An error occured while trying to get token from {disco.TokenEndpoint}: {tokenResponse.Error}", tokenResponse.Exception);
            }
            return tokenResponse.AccessToken;
        }
    }
}
