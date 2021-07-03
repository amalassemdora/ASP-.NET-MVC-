using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day4Task.Models;
namespace Day4Task.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        PlogContext db = new PlogContext();
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
    }
}