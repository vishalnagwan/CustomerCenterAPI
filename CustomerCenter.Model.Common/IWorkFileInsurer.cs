namespace Uniban.GlassFileData.Model.Common {
    public interface IWorkFileInsurer {
        string InsurerGuid { get; set; }
        int JobNumber { get; set; }
        int WorkFileId { get; set; }
    }
}