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

        public DbSet<EmailAddress> EmailList { get; set; }
        public DbSet<DownTimeEvent> DownTimeEvents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DownTimeType> DownTimeTypes { get; set; }
        public DbSet<AlertThreshold> AlertThresholds { get; set; }

    }
}