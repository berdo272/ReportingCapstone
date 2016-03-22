using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportingCapstone.Models
{
    public class AlertThreshold
    {
        public int Id { get; set; }
        public int PercentDowntimeThreshold { get; set; }
        public string AditionalAlertNotes { get; set; }
    }
}