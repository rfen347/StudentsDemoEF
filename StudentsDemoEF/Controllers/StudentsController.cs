using StudentsDemoEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsDemoEF.Controllers
{
    public class StudentsController : Controller
    {
      StudentContext context = new StudentContext();
      // GET: Students
        public ActionResult Index()
        {
            return View(context.Students.ToList());
        }

      // GET: Students/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: Students/Create
      [HttpPost]
      public ActionResult Create(Student student)
      {
         try
         {
            if (ModelState.IsValid)
            {
               context.Students.Add(student);
               context.SaveChanges();
            }

            return RedirectToAction("Index");
         }
         catch
         {
            return View(student);
         }
      }

      public ActionResult AddCourse(int Id)
      {
         Student student = context.Students.FirstOrDefault(x => x.StudentId == Id);
         if (student!=null)
         {
            Course course = new Models.Course();
            course.Students  = new List<Student>();
            course.Students.Add(student);
            return View(course);
         }
         else
         {
            return RedirectToAction("Create");
         }
      }

      [HttpPost]
      public ActionResult AddCourse(Course course)
      {
         //Assignment Validation to check if course already eists
        
            int studentid = course.Students[0].StudentId;

            Course newcourse = context.Courses.FirstOrDefault(x => x.CourseTitle == course.CourseTitle);
            context.Students.FirstOrDefault(x => x.StudentId == studentid).Courses.Add(newcourse);

            context.SaveChanges();
            return RedirectToAction("Index");
       
       
        
      }

      // GET: Students/Details/5
      public ActionResult Details(int id)
      {
         return View();
      }



        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
         var student = context.Students.FirstOrDefault(x => x.StudentId == id);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
            var stu = context.Students.Find( id);

            if (stu!=null)
            {
               context.Entry(stu).CurrentValues.SetValues(student);
               context.SaveChanges();
            }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
