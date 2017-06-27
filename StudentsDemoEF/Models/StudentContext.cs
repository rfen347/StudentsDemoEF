using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
 

namespace StudentsDemoEF.Models
{
   public class StudentContext : DbContext
   {
      public StudentContext() : base("name = DefaultConnection")
      {

      }

      public virtual DbSet<Student> Students { get; set; }
      public virtual DbSet<Course> Courses { get; set; }
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Student>()
            .HasMany(c => c.Courses)
            .WithMany(s => s.Students)
            .Map(m =>
            {
               m.ToTable("StudentCourses");
               m.MapLeftKey("StudentID");
               m.MapRightKey("CourseID");
            }
            );
         base.OnModelCreating(modelBuilder);
      }

   }
}