namespace MyAttendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "StandardId", "dbo.Standards");
            DropForeignKey("dbo.Students", "UserId", "dbo.UserModels");
            DropIndex("dbo.Students", new[] { "StandardId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropTable("dbo.Students");
            DropTable("dbo.Standards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Students", "UserId");
            CreateIndex("dbo.Students", "StandardId");
            AddForeignKey("dbo.Students", "UserId", "dbo.UserModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "StandardId", "dbo.Standards", "Id", cascadeDelete: true);
        }
    }
}
