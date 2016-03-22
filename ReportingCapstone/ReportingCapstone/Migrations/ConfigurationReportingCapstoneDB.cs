namespace ManufacturingReporting.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ReportingCapstone.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationReportingCapstoneDB : DbMigrationsConfiguration<ReportingCapstone.Models.ReportingCapstoneDBContext>
    {
        public ConfigurationReportingCapstoneDB()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ReportingCapstone.Models.ReportingCapstoneDBContext context)
        {

        }
    }
}
