using System;

namespace Uniban.GlassFileData.Proxies.Models.Phoenix
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string UserGuid { get; set; }
        public int? OfficeId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public int? LocationId { get; set; }
        public int? SecondLocationId { get; set; }
        public int ContactInfoId { get; set; }
        public int? SecondContactInfoId { get; set; }
        public string EMail { get; set; }
        public string Notes { get; set; }
        public decimal? TimeZoneOffset { get; set; }
        public int LanguageId { get; set; }
        public int CultureId { get; set; }
        public string Mobile { get; set; }
        public string MobileEmail { get; set; }
        public string NotifyEmail { get; set; }
        public int? UserStatusId { get; set; }
        public bool Active { get; set; }
        public DateTime? LastEmailAddressConfirmationDate { get; set; }
        public DateTime? LastEmailAddressConfirmationIgnoreDate { get; set; }
        public Location Location { get; set; }
        public Location SecondLocation { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ContactInfo SecondContactInfo { get; set; }
        public Timezone TimeZone { get; set; }
        public Culture Culture { get; set; }
    }
}