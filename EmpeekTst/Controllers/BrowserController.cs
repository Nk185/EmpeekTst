using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpeekTst.Models;

namespace EmpeekTst.Controllers
{
    public class BrowserController : Controller
    {
        //
        // GET: /Browser/
        public ActionResult Index(string chosenDriveName)
        {
            DirectoryContent directoryContent = new DirectoryContent();
            directoryContent.DirPath = new DriveInfo(chosenDriveName).RootDirectory.FullName;

            return View(directoryContent);
        }
	}
}