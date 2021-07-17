namespace MyAttendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.String(),
                        Address = c.String(),
                        StandardId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Standards", t => t.StandardId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.StandardId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "UserId", "dbo.UserModels");
            DropForeignKey("dbo.Students", "UserId", "dbo.UserModels");
            DropForeignKey("dbo.Students", "StandardId", "dbo.Standards");
            DropIndex("dbo.Teachers", new[] { "UserId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.Students", new[] { "StandardId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Standards");
            DropTable("dbo.Students");
        }
    }
}
