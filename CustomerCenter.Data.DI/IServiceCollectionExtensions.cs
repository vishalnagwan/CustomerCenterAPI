using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCenter.Data.DI
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlServer(configuration["DataConnection"]);
            });

            return services;
        }
    }
}
