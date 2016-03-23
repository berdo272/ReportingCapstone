namespace ReportingCapstone.ReportingCapstoneDBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlertThresholds",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PercentDowntimeThreshold = c.Int(nullable: false),
                    AditionalAlertNotes = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Departments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DepartmentName = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.DownTimeEvents",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DownTimeTypeId = c.Int(nullable: false),
                    DepartmentId = c.Int(nullable: false),
                    Date = c.DateTime(nullable: false),
                    Duration = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DownTimeTypes", t => t.DownTimeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                ;


            CreateTable(
                "dbo.DownTimeTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.DownTimeEvents", "DownTimeTypeId", "dbo.DownTimeTypes");
            DropForeignKey("dbo.DownTimeEvents", "DepartmentId", "dbo.Departments");
            DropTable("dbo.DownTimeTypes");
            DropTable("dbo.DownTimeEvents");
            DropTable("dbo.Departments");
            DropTable("dbo.AlertThresholds");
        }
    }
}
