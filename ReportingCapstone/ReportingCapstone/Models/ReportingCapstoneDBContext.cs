using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReportingCapstone.Models
{
    public class ReportingCapstoneDBContext : DbContext
    {
        public ReportingCapstoneDBContext() : base("defaultConnection")
        {

        }

        public DbSet<DownTimeEvent> DowntimeLog { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DownTimeType> ErrorCodes { get; set; }
        public DbSet<AlertThreshold> Alerts { get; set; }

    }
}