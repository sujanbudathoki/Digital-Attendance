namespace MyAttendance.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class a3456 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAttends",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StudentId = c.Int(nullable: false),
                    dateId = c.Int(nullable: false),
                    CurrentDate = c.DateTime(nullable: false),
                    presentFlag = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.dateId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.dateId);

            CreateTable(
                "dbo.Dates",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),

                    date = c.DateTime(nullable: false),
                    isHolidayFlag = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);



        }

        public override void Down()
        {
            DropForeignKey("dbo.StudentAttends", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentAttends", "dateId", "dbo.Dates");
            DropForeignKey("dbo.Dates", "StandardId", "dbo.Standards");
            DropIndex("dbo.Dates", new[] { "StandardId" });
            DropIndex("dbo.StudentAttends", new[] { "dateId" });
            DropIndex("dbo.StudentAttends", new[] { "StudentId" });
            DropTable("dbo.Dates");
            DropTable("dbo.StudentAttends");
        }
    }
}
