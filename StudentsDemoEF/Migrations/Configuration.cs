namespace StudentsDemoEF.Migrations
{
   using Models;
   using System;
   using System.Collections.Generic;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;

   internal sealed class Configuration : DbMigrationsConfiguration<StudentsDemoEF.Models.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentsDemoEF.Models.StudentContext context)
        {
         //  This method will be called after migrating to the latest version.

         //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
         //  to avoid creating duplicate seed data. E.g.
         //
         //    context.People.AddOrUpdate(
         //      p => p.FullName,
         //      new Person { FullName = "Andrew Peters" },
         //      new Person { FullName = "Brice Lambson" },
         //      new Person { FullName = "Rowan Miller" }
         //    );
         //

         IList<Course> defaultCourses = new List<Course>();

         defaultCourses.Add(new Course() { CourseId = 1, CourseTitle = EnumCourse.JAVA, Fee = 300 });
         defaultCourses.Add(new Course() { CourseId = 2, CourseTitle = EnumCourse.MVC, Fee = 500 });
         defaultCourses.Add(new Course() { CourseId = 3, CourseTitle = EnumCourse.Python, Fee = 200 });



         foreach (Course course in defaultCourses)
            context.Courses.AddOrUpdate(course);
         base.Seed(context);
      }
    }
}
