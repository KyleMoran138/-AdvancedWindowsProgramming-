namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCourseContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Course_id", "dbo.Courses");
            DropForeignKey("dbo.People", "Course_id1", "dbo.Courses");
            DropIndex("dbo.People", new[] { "Course_id" });
            DropIndex("dbo.People", new[] { "Course_id1" });
            DropColumn("dbo.People", "Course_id");
            DropColumn("dbo.People", "Course_id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Course_id1", c => c.Guid());
            AddColumn("dbo.People", "Course_id", c => c.Guid());
            CreateIndex("dbo.People", "Course_id1");
            CreateIndex("dbo.People", "Course_id");
            AddForeignKey("dbo.People", "Course_id1", "dbo.Courses", "id");
            AddForeignKey("dbo.People", "Course_id", "dbo.Courses", "id");
        }
    }
}
