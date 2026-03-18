using System;
using System.Collections.Generic;
using System.Text;

namespace Uniban.DemoiGlassData.Services.Models
{
    public class SageWorkFileModel
    {
        public int workfileId { get; set; }
        public int GC_JOBNBR { get; set; }
        public string BreakDetail { get; set; }
        public string BreakLocation { get; set; }
        public int Ceded { get; set; }
        public string GC_CAUSE_O_LOSS { get; set; }
        public string GC_CUSTADDR1 { get; set; }
        public string GC_CUSTCITY { get; set; }
        public string GC_CustDriver { get; set; }
        public string GC_CUSTFIRST { get; set; }
        public string GC_CUSTHOMETEL { get; set; }
        public string GC_CUSTLAST { get; set; }
        public string GC_CUSTPOST { get; set; }
        public string GC_CUSTPROVCODE { get; set; }
        public string GC_CUSTWORKEXT { get; set; }
        public string GC_CUSTWORKTEL { get; set; }
        public string GC_DRIVERLIC { get; set; }
        public DateTime GC_INITCALLDATE { get; set; }

        public DateTime GC_LASTCALLDATE { get; set; }
        public DateTime? GC_LOSSDATE { get; set; }
        public string GC_Model { get; set; }
        public double? GC_POLDEDUCT { get; set; }
        public string GC_POLNBR { get; set; }
        public string GC_VEHLICENCE { get; set; }
        public string GC_VEHMAKE { get; set; }
        public string GC_VEHMODEL { get; set; }
        public string GC_VEHSTYLE { get; set; }
        public string GC_VEHVIN { get; set; }
        public string GC_VEHYEAR { get; set; }
        public int? KMGAA { get; set; }
        public DateTime VENINVDATE { get; set; }
        public string CLAIMNMBR { get; set; }
        public int? GC_VEHOdometer { get; set; }
    }
}
