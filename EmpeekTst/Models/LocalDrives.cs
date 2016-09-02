using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Services.DriveServices;

namespace EmpeekTst.Models
{
    public class LocalDrives
    {
        public DriveInfo[] Drives { get { return HDDInspector.GetDrives.Where(d => d.IsReady).ToArray(); } }
    }
}