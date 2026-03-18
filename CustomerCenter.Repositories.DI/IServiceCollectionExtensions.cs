using Microsoft.Extensions.DependencyInjection;
using CustomerCenter.Repositories.Abstractions;

namespace CustomerCenter.Repositories.DI
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection col)
        {            
            col.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
