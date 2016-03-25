using ReportingCapstone.Models;

namespace ReportingCapstone.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ReportingCapstone.Models;
    using System;
    using System.Collections.Generic;
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
            List<DownTimeType> downTimeTypes = new List<DownTimeType>
            {
                new DownTimeType
                {
                    Description = "Component Shortage"
                },
                new DownTimeType
                {
                    Description = "Paint Popper Down"
                },
                new DownTimeType
                {
                    Description = "Printer Ribbon Replacement"
                },
                new DownTimeType
                {
                    Description = "Waiting For Material Handler"
                },
                new DownTimeType
                {
                    Description = "Change Over"
                },
                new DownTimeType
                {
                    Description = "Copper Crush Washer Replacement"
                },
                new DownTimeType
                {
                    Description = "Evac and Fill Failure"
                },
                new DownTimeType
                {
                    Description = "Printer Label Change"
                },
                new DownTimeType
                {
                    Description = "Waiting for Oil Drum Replacement"
                },
                new DownTimeType
                {
                    Description = "Problem Solving With Engineer"
                },
                new DownTimeType
                {
                    Description = "Piston Pusher Inop"
                },
                new DownTimeType
                {
                    Description = "6 Piston tester Down"
                },
            };
            downTimeTypes.ForEach(b => context.DownTimeTypes.Add(b));

            context.SaveChanges();

            List<Department> departments = new List<Department>
            {
                new Department
                {
                    DepartmentName = "Tricept"
                },
                new Department
                {
                    DepartmentName = "A8_0108"
                },
                new Department
                {
                    DepartmentName = "A8_0206"
                },
                new Department
                {
                    DepartmentName = "A8_0212"
                },
                new Department
                {
                    DepartmentName = "B5_0106"
                },
                new Department
                {
                    DepartmentName = "H6_0219"
                },
            };
            departments.ForEach(b => context.Departments.Add(b));

            context.SaveChanges();
                     
        }
    }
}
