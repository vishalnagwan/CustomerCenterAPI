using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCenter.Domain
{
    public class AuthenticationOptions
    {
        public string Authority { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ApiName { get; set; }
    }
}
