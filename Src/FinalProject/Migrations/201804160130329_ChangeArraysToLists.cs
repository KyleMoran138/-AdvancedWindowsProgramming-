namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeArraysToLists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Course_id", c => c.Guid());
            AddColumn("dbo.People", "Course_id1", c => c.Guid());
            CreateIndex("dbo.People", "Course_id");
            CreateIndex("dbo.People", "Course_id1");
            AddForeignKey("dbo.People", "Course_id", "dbo.Courses", "id");
            AddForeignKey("dbo.People", "Course_id1", "dbo.Courses", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Course_id1", "dbo.Courses");
            DropForeignKey("dbo.People", "Course_id", "dbo.Courses");
            DropIndex("dbo.People", new[] { "Course_id1" });
            DropIndex("dbo.People", new[] { "Course_id" });
            DropColumn("dbo.People", "Course_id1");
            DropColumn("dbo.People", "Course_id");
        }
    }
}
