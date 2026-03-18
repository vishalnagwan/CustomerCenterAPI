namespace Uniban.GlassFileData.Proxies.Models.Phoenix
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string RegionCode { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string OtherRegion { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}