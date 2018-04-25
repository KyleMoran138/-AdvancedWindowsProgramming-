namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDatabaseUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cirricliums",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        Name = c.String(),
                        MinYears = c.Int(nullable: false),
                        cirq_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cirricliums", t => t.cirq_id)
                .Index(t => t.cirq_id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        firstName = c.String(),
                        lastName = c.String(),
                        username = c.String(),
                        pass = c.String(),
                        Title = c.String(),
                        Role = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Degrees", "cirq_id", "dbo.Cirricliums");
            DropIndex("dbo.Degrees", new[] { "cirq_id" });
            DropTable("dbo.People");
            DropTable("dbo.Degrees");
            DropTable("dbo.Courses");
            DropTable("dbo.Cirricliums");
        }
    }
}
