using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_App.Models;
namespace Student_App.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        ITIContext db = new ITIContext();
        public ActionResult InstBydept(int id1)
        {
            List<Instructor> ins = db.Instructors.Where(n => n.Dept_Id == id1).ToList();
            ViewBag.inst = ins;
            return PartialView();
        }
        public ActionResult Index()
        {
            SelectList s = new SelectList(db.Departments.ToList(), "Dept_Id", "Dept_Name");
            return View(s);
        }
       
    }
}