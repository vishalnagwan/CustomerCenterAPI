using System.Collections.Generic;

namespace Uniban.GlassFileData.Proxies.Models.Phoenix
{
    public class Office
    {
        public int OfficeId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int? ParentOfficeId { get; set; }
        public int LocationId { get; set; }
        public int ContactInfoId { get; set; }
        public decimal? TimeZoneOffset { get; set; }
        public int? LanguageId { get; set; }
        public int? CultureId { get; set; }
        public IEnumerable<UserProfile> UserProfiles { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Location Location { get; set; }
        public IEnumerable<OfficeTypes> OfficeType { get; set; }
    }
}