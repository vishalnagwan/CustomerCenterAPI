using System.Collections.Generic;
using Uniban.GlassFileData.Domain;
using Uniban.GlassFileData.Reports.Models;

namespace Uniban.GlassFileData.Reports.Abstractions
{
    public interface IReportModelMapper
    {
        Quotation GetQuotation(WorkOrder workFile, Proxies.Models.Phoenix.Company insurer, Proxies.Models.Phoenix.Company vendor, string vendorBanner, Dictionary<string,string> translations, ReportConfigurations configurations);
        VehicleKeeper GetVehicleKeeper(WorkOrder workFile);

    }
}
