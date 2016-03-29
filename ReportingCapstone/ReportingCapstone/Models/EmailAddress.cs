using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReportingCapstone.Models
{
    public class EmailAddress
    {
        public int Id { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}