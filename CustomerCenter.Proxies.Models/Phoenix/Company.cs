using System.Collections.Generic;

namespace Uniban.GlassFileData.Proxies.Models.Phoenix
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyGuid { get; set; }
        public string Name { get; set; }
        public string AffiliationName { get; set; }
        public string AlternateName { get; set; }
        public int? BillToCompanyId { get; set; }
        public int? PrimaryOfficeId { get; set; }
        public int? PrimaryContactUserId { get; set; }
        public bool Active { get; set; }
        public int? CompanyTypeId { get; set; }
        public int? BillToOfficeId { get; set; }
        public CompanyType CompanyType { get; set; }
        public UserProfile PrimaryContactUser { get; set; }
        public IEnumerable<Journal> Journal { get; set; }
        public IEnumerable<Office> Office { get; set; }
        public IEnumerable<int> ParentCompanyIds { get; set; }
        public VendorCategory VendorCategory { get; set; }
        public string BusinessCode { get; set; }
        public string BranchId { get; set; }
        public bool IsIntegrated { get; set; }
        public IEnumerable<string> ParentCompanyGuids { get; set; }
    }
}
