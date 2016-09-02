using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpeekTst.Models;

namespace EmpeekTst.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            LocalDrives drives = new LocalDrives();
            return View(drives);
        }
    }
}