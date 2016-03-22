namespace ManufacturingReporting.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ReportingCapstone.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationManufacturingDB : DbMigrationsConfiguration<ReportingCapstone.Models.ApplicationDbContext>
    {
        public ConfigurationManufacturingDB()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ReportingCapstone.Models.ApplicationDbContext context)
        {

        }
    }
}
