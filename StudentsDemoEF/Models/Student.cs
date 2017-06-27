using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentsDemoEF.Models
{
   public class Student
   {
      public int StudentId { get; set; }
      
      public string Name { get; set; }
      public string City { get; set; }
      [EmailAddress]
      public string Email { get; set; }
      [Range(20, 30)]
      public int Age { get; set; }
     
     

      public virtual IList<Course> Courses { get; set; }
    

   }
}