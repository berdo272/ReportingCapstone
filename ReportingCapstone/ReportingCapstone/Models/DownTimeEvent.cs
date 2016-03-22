using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportingCapstone.Models
{
    public class DownTimeEvent
    {
        public int Id { get; set; }
        public int DownTimeTypeId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }

    }
}