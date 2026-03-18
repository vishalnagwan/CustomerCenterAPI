using System;
using System.Collections.Generic;
using System.Text;
using Uniban.DemoiGlassData.Domain;
using Proxy = Uniban.DemoiGlassData.Proxies.Models.Phoenix;

namespace Uniban.DemoiGlassData.Services.Models
{
    public class QuoteDownload
    {
        public Proxy.Company Vendor { get; set; }
        public Proxy.Company Insurer { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
