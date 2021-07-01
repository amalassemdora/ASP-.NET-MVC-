using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Edit_Design.Models;

namespace MVC_Edit_Design.Controllers
{
    public class StudentController : Controller
    {
        ITIContext db = new ITIContext(); 
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        public ActionResult Create()
		{
            List<Department> d = db.Departments.ToList();
            SelectList dept = new SelectList(d, "Dept_Id", "Dept_Name");
            ViewBag.dept = dept;
            return View();
		}
        [HttpPost]
        public ActionResult Create(Student s,HttpPostedFileBase img,HttpPostedFileBase file)
        { 
            //Image
            if(img != null)
			{
                //upload file on server
                img.SaveAs(Server.MapPath($"~/Attach/{img.FileName}"));
                //save path in student object
                s.photo = img.FileName;

			}
            //file
            if (file != null)
            {
                //upload file on server
                img.SaveAs(Server.MapPath($"~/Attach/{file.FileName}"));
                //save path in student object
                s.CV = file.FileName;

            }

            if (ModelState.IsValid)
			{
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
			}
			else
			{
                List<Department> d = db.Departments.ToList();
                SelectList dept = new SelectList(d, "Dept_Id", "Dept_Name");
                ViewBag.dept = dept;
                return View();
            }
          
        }
        public ActionResult remove(int id)
		{
            Student s = db.Students.Where(n => n.St_Id == id).SingleOrDefault();
            db.Students.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult edit(int id,HttpPostedFileBase img,HttpPostedFileBase file)
        {
            Student s = db.Students.Where(n => n.St_Id == id).SingleOrDefault();
            List<Department> d = db.Departments.ToList();
            SelectList dept = new SelectList(d, "Dept_Id", "Dept_Name");
            ViewBag.dept = dept;
            //Image
            if (img != null)
            {
                //upload file on server
                img.SaveAs(Server.MapPath($"~/Attach/{img.FileName}"));
                //save path in student object
                s.photo = img.FileName;

            }
            //file
            if (file != null)
            {
                //upload file on server
                img.SaveAs(Server.MapPath($"~/Attach/{file.FileName}"));
                //save path in student object
                s.CV = file.FileName;
            }
               
            return View(s);
        }
        [HttpPost]
        public ActionResult edit(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                List<Department> d = db.Departments.ToList();
                SelectList dept = new SelectList(d, "Dept_Id", "Dept_Name");
                ViewBag.dept = dept;
                return View();
            }


        }
        public ActionResult download(string name)
		{
            return File($"~/Attach/{name}", "application/pdf");
		}
        public ActionResult about()
        {
            return View();
        }
        public ActionResult contactus()
        {
            return View();
        }

        public ActionResult news()
        {
            return View();
        }
    }
}