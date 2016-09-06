using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpeekTst.Models;
using Services.DriveServices;

namespace EmpeekTst.Controllers
{
    public class BrowserController : Controller
    {
        //
        // GET: /Browser/
        public ActionResult Index(string chosenDriveName)
        {
            if (chosenDriveName == null)
                chosenDriveName = @"C:\";

            return View((object)chosenDriveName);
        }
	}
}