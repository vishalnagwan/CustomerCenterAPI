namespace Uniban.GlassFileData.Proxies.Models.Phoenix
{
    public class Journal
    {
        public int JournalId { get; set; }
        public int CompanyId { get; set; }
        public int? UserProfileId { get; set; }
        public string Note { get; set; }
    }
}