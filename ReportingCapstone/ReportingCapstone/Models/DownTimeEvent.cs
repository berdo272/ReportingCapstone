using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Department")]
        public string departmentName { get; set; }
        [DisplayName("Downtime Type")]
        public string ErrorTypeName { get; set; }

        


    }
}