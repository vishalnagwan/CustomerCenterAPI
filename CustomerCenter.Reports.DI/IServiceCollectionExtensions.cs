using Microsoft.Extensions.DependencyInjection;
using Uniban.GlassFileData.Reports.Abstractions;

namespace Uniban.GlassFileData.Reports.DI
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureReports(this IServiceCollection col)
        {
            col.AddScoped<IReportService, ReportService>();
            col.AddSingleton<IReportModelMapper, ReportModelMapper>();
        }
    }
}
