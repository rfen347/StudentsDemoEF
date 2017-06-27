namespace StudentsDemoEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseTitle = c.Int(nullable: false),
                        Fee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseID })
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "CourseID" });
            DropIndex("dbo.StudentCourses", new[] { "StudentID" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
