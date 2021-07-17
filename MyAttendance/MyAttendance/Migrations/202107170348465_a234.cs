namespace MyAttendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a234 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "UserId", "dbo.UserModels");
            DropIndex("dbo.Teachers", new[] { "UserId" });
            AddColumn("dbo.UserModels", "Name", c => c.String());
            AddColumn("dbo.UserModels", "Address", c => c.String());
            AddColumn("dbo.UserModels", "Gender", c => c.String());
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.UserModels", "Gender");
            DropColumn("dbo.UserModels", "Address");
            DropColumn("dbo.UserModels", "Name");
            CreateIndex("dbo.Teachers", "UserId");
            AddForeignKey("dbo.Teachers", "UserId", "dbo.UserModels", "Id", cascadeDelete: true);
        }
    }
}
