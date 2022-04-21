using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RDLCReportViewer.Controllers
{
    public class MySessionTestController : Controller
    {
        // GET: MySessionTest
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createStudent(Student std)
        {
            HttpContext.Session["MyVar"] = std;
            List<Student> students = new List<Student>();
            students.Add(std);
            return Json(students, JsonRequestBehavior.AllowGet);
        }


        public class Student
        {
            public int studentID { get; set; }
            public string studentName { get; set; }
            public string studentAddress { get; set; }
        }

    }
}