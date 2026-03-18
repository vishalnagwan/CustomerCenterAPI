namespace Uniban.GlassFileData.Reports.Models
{
    public class InvoiceDetail
    {
        public string Description { get; set; }
        public double? Quantity { get; set; }
        public string PartNumber { get; set; }
        public decimal? Price { get; set; }
        public decimal? Labour { get; set; }
    }
}
