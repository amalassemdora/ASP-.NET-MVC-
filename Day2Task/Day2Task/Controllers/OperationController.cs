using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2Task.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        public ViewResult register()
		{
            return View();
		}
        public ViewResult show(int id,string name,int age)
		{
            return View();
		}
    }
}