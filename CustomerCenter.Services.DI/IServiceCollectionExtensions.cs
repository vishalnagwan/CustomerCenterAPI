using CustomerCenter.Services;
using Microsoft.Extensions.DependencyInjection;
using CustomerCenter.Services.Abstractions;

namespace CustomerCenter.Services.DI
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureBusinessLogics(this IServiceCollection col)
        {            
            col.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
