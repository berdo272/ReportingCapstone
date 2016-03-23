using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ReportingCapstone.Models
{
    public class AlertThreshold
    {
        public int Id { get; set; }
        [DisplayName("Downtime Threshold")]
        public int PercentDowntimeThreshold { get; set; }
        [DisplayName("Additional Notes")]
        public string AditionalAlertNotes { get; set; }
    }
}