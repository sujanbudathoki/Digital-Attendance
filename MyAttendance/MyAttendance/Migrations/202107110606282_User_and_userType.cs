namespace MyAttendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_and_userType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
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
            DropIndex("dbo.UserModels", new[] { "UserTypeId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserModels");
        }
    }
}
