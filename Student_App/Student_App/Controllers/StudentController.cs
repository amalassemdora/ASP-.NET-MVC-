using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_App.Models;
namespace Student_App.Controllers
{
    public class StudentController : Controller
    {
        ITIContext db = new ITIContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
		{
            return View();
		}
        [HttpPost]
		public ActionResult Register(Student s, HttpPostedFileBase img)
		{
			img.SaveAs(Server.MapPath($"~/Attach/{img.FileName}"));
			s.photo = img.FileName;
			if (ModelState.IsValid)
			{
				db.Students.Add(s);
				db.SaveChanges();
				return RedirectToAction("Login");
			}
			else
			{
				return View();
			}
		}

		public ActionResult Login()
		{
			//check cookie exist or not
			if (Request.Cookies["fullstack"] != null)
			{
				Session["userid"] = Request.Cookies["fullstack"].Values["id"];
				return RedirectToAction("profile");
			}

			return View();
		}
        [HttpPost]
        public ActionResult Login([Bind(Include ="Email,Password")]Student s,bool rember)
        {
            Student st = db.Students.Where(n => n.Email == s.Email && n.Password == s.Password).SingleOrDefault();
            if(st != null)
			{
				if (rember)
				{ 
					HttpCookie co = new HttpCookie("fullstack");
					co.Values.Add("id", st.St_Id.ToString());
					co.Expires = DateTime.Now.AddDays(10);
					Response.Cookies.Add(co);
				}
                Session.Add("userid", st.St_Id);
                return RedirectToAction("profile");
			}
			else
			{
                ViewBag.status = "Incorrect Email or Password";
                return View();
			}
        }
        public ActionResult profile()
		{
            int id = int.Parse(Session["userid"].ToString());
            Student s = db.Students.Where(n => n.St_Id == id).SingleOrDefault();
            return View(s);
		}

		public ActionResult Logout()
		{
			Session["userid"] = null;
			//remove cookie in logout by expire date
			HttpCookie c = new HttpCookie("fullstack");
			c.Expires = DateTime.Now.AddDays(-20);
			Response.Cookies.Add(c);

			return RedirectToAction("Login");
		}
		public ActionResult check(string email)
		{
			Student st = db.Students.Where(n => n.Email == email).SingleOrDefault();
			if (st == null)
			{
				return Json(true, JsonRequestBehavior.AllowGet);
			}
			else
			{
				return Json(false, JsonRequestBehavior.AllowGet);
			}
		}
	}
}