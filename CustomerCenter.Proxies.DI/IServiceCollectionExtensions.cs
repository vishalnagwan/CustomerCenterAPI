using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Uniban.GlassFileData.Proxies.Abstractions;

namespace Uniban.GlassFileData.Proxies.DI
{
    public static class IServiceCollectionExtensions
    {
        public static void AddProxies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProxyAuthenticationOptions>(configuration);
            services.Configure<ProxiesOptions>(configuration.GetSection("Proxies"));
            services.AddTransient<PhoenixDelegatingHandler>();

            services
                .AddHttpClient<IPhoenixProxy, PhoenixProxy>((serviceProvider, httpClient) =>
                {
                    var proxyInfo = serviceProvider.GetService<IOptions<ProxiesOptions>>();
                    httpClient.BaseAddress = new Uri(proxyInfo.Value.Phoenix.Uri);
                })
                .AddHttpMessageHandler<PhoenixDelegatingHandler>();
        }
    }
}
