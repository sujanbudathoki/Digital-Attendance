namespace MyAttendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateMigrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dates", "date_Id", c => c.Int());
            CreateIndex("dbo.Dates", "date_Id");
            AddForeignKey("dbo.Dates", "date_Id", "dbo.Dates", "Id");
            DropColumn("dbo.Dates", "date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dates", "date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Dates", "date_Id", "dbo.Dates");
            DropIndex("dbo.Dates", new[] { "date_Id" });
            DropColumn("dbo.Dates", "date_Id");
        }
    }
}
