using System.Threading.Tasks;
using Uniban.GlassFileData.Proxies.Models;
using Uniban.GlassFileData.Proxies.Models.Phoenix;

namespace Uniban.GlassFileData.Proxies.Abstractions
{
    public interface IPhoenixProxy
    {
        Task<ProxyResponse<Company>> GetCompanyAsync(string companyGuid);
        Task<ProxyResponse<string>> GetVendorBannerBusinessCode(string vendorGuid);
    }
}
