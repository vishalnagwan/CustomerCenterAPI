using System.Threading.Tasks;

namespace Uniban.GlassFileData.Reports.Abstractions
{
    public interface IReportService
    {
        Task<byte[]> GetVehicleKeeperReportAsync(int workFileId);
        Task<byte[]> GetQuotationReportAsync(int workFileId);
    }
}
