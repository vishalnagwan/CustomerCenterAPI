using System;
using System.Collections.Generic;

namespace Uniban.GlassFileData.Reports.Models
{
    public class Quotation
    {
        //Rule Identifier
        public string Banner { get; set; }

        //Header
        public string FaxFlag { get; set; }
        public string WorkOrderNumber { get; set; }

        //First Column
        public Insurer Insurer { get; set; }
        public Vendor Vendor { get; set; }

        //Second Column
        public DateTime? WorkOrderDate { get; set; }
        public Insured Insured { get; set; }
        public string PolicyNumber { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime? DateOfLoss { get; set; }
        public string DriverGuardian { get; set; }
        public string CauseOfLoss { get; set; }

        //Vehicle Information
        public Vehicle Vehicle { get; set; }

        //Parts
        public IEnumerable<InvoiceDetail> Parts { get; set; }

        //Footer
        public string Notes { get; set; }
        public decimal? TotalParts { get; set; }
        public decimal? TotalLabour { get; set; }
        public decimal? GST_HST { get; set; }
        public decimal? PST { get; set; }
        public decimal? Deductible { get; set; }
        public decimal? TotalPayable { get; set; }

        public bool ShowAcceptOemText { get; set; }
        public string AcceptAftermarket { get; set; }
        public string OemAcceptOemText { get; set; }
        public bool CalibrationFound { get; set; }
        public string InvoicesEmail { get; set; }

        public Dictionary<string, string> Translations { get; set; }
        public bool ShowNotesSection { get; set; }
        public bool ShowEmailMentionInNotes { get; set; }
        public bool ShowCalibrationNote { get; set; }

        public static string GetTranslation(Dictionary<string, string> translations, string key)
        {
            translations.TryGetValue(key, out var value);
            return value ?? string.Empty;
        }

        public static string GetTranslationWithEmail(Dictionary<string, string> translations, string key, string email)
        {
            translations.TryGetValue(key, out var value);
            return value?.Replace("{email}", email) ?? string.Empty;
        }

    }
}
