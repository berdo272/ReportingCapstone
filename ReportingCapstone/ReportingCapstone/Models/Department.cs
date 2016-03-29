using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReportingCapstone.Models
{
    public class Department
    {
        public int Id { get; set; }
        [DisplayName("DepartmentName")]
        public string DepartmentName { get; set; }
    }
}