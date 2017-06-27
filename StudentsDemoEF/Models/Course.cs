using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentsDemoEF.Models
{
   public class Course
   {
      public int CourseId { get; set; }
      public EnumCourse CourseTitle { get; set; }
      public int Fee { get; set; }

      public virtual IList<Student> Students { get; set; }

   }

   public enum EnumCourse
   {
      None,MVC,JAVA,Python
   }
}