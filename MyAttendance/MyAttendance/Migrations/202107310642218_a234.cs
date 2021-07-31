namespace MyAttendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a234 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandardName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Roll = c.Int(nullable: false),
                        StudentName = c.String(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Standards", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModels", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Standards");
            DropIndex("dbo.UserModels", new[] { "UserTypeId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserModels");
            DropTable("dbo.Students");
            DropTable("dbo.Standards");
        }
    }
}
