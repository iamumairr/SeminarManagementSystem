namespace SeminarManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SeminarOrganizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeminarId = c.Int(nullable: false),
                        OrganizerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId, cascadeDelete: true)
                .ForeignKey("dbo.Seminars", t => t.SeminarId, cascadeDelete: true)
                .Index(t => t.SeminarId)
                .Index(t => t.OrganizerId);
            
            CreateTable(
                "dbo.Seminars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeminarTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(nullable: false),
                        SeminarDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeminarTypes", t => t.SeminarTypeId, cascadeDelete: true)
                .Index(t => t.SeminarTypeId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttendeeId = c.Int(nullable: false),
                        SeminarId = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendees", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Seminars", t => t.SeminarId, cascadeDelete: true)
                .Index(t => t.AttendeeId)
                .Index(t => t.SeminarId);
            
            CreateTable(
                "dbo.SeminarTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seminars", "SeminarTypeId", "dbo.SeminarTypes");
            DropForeignKey("dbo.SeminarOrganizers", "SeminarId", "dbo.Seminars");
            DropForeignKey("dbo.Registrations", "SeminarId", "dbo.Seminars");
            DropForeignKey("dbo.Registrations", "AttendeeId", "dbo.Attendees");
            DropForeignKey("dbo.SeminarOrganizers", "OrganizerId", "dbo.Organizers");
            DropIndex("dbo.Registrations", new[] { "SeminarId" });
            DropIndex("dbo.Registrations", new[] { "AttendeeId" });
            DropIndex("dbo.Seminars", new[] { "SeminarTypeId" });
            DropIndex("dbo.SeminarOrganizers", new[] { "OrganizerId" });
            DropIndex("dbo.SeminarOrganizers", new[] { "SeminarId" });
            DropTable("dbo.SeminarTypes");
            DropTable("dbo.Registrations");
            DropTable("dbo.Seminars");
            DropTable("dbo.SeminarOrganizers");
            DropTable("dbo.Organizers");
            DropTable("dbo.Attendees");
        }
    }
}
