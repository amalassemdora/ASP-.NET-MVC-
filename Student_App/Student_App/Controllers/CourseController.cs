using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_App.Models;

namespace Student_App.Controllers
{
    public class CourseController : Controller
    {
        ITIContext db = new ITIContext();
        // GET: Course
        public ActionResult CrsByTopic(int id)
        {
            List<Course> Crs = db.Courses.Where(n => n.Top_Id == id).ToList();
            ViewBag.course = Crs;
            return PartialView();
        }
        public ActionResult Index()
        {
            SelectList top= new SelectList(db.Topics.ToList(),"Top_Id", "Top_Name");
            return View(top);
        }
       
    }
}