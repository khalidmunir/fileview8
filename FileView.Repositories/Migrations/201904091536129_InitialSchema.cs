namespace FileView.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastLogin = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Level = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        BusinessArea = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                        Volume = c.String(),
                        Size = c.Int(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        AccessTime = c.DateTime(nullable: false),
                        MD5 = c.String(),
                        SecurityClassification = c.String(),
                        BusinessClassification = c.String(),
                        Extension = c.String(),
                        MimeType = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileInfo", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.FileInfo", new[] { "EmployeeId" });
            DropTable("dbo.FileInfo");
            DropTable("dbo.Employees");
        }
    }
}
