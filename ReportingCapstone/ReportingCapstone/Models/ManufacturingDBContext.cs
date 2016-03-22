using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManufacturingReporting.Models
{
    public class ManufacturingDBContext : DbContext
    {
        public ManufacturingDBContext() : base("defaultConnection")
        {

        }

        public DbSet<DownTimeEvent> DowntimeLog { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<DownTimeTypes> ErrorCodes { get; set; }

    }
}