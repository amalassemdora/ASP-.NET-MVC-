using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2Task.Models;
namespace Day2Task.Controllers
{
    public class CourseController : Controller
    {
        ITIContext db = new ITIContext();
        public ViewResult Index()
        {
            List<Course> crs = db.Courses.ToList(); 
            return View(crs);
        }
        public ActionResult create()
		{
            List<Topic> tops = db.Topics.ToList();
            ViewBag.tops = tops;
            return View();
		}
        public ActionResult Save(Course c)
		{
            db.Courses.Add(c);
            db.SaveChanges();
            return RedirectToAction("index");
		}
        public ActionResult delete(int id)
		{
            Course c = db.Courses.Where(n => n.Crs_Id == id).SingleOrDefault();
            db.Courses.Remove(c);
            db.SaveChanges();
            return RedirectToAction("index");
		}
    }
}