using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpeekTst.Models;
using Services.DriveServices;

namespace EmpeekTst.Controllers
{
    public class RequestError
    {
        public string ErrorMessage { get; set; }
        public bool OpenDriveSelectionDlg { get; set; }
    }

    public class BrowsingController : ApiController
    {
        [HttpGet]
        public object GetDirectoryByPath(string dir_path)
        {
            if (Directory.Exists(dir_path))
            {
                DirectoryContent dr = new DirectoryContent(dir_path);
                dr.FilesCountWithSpecificCondition = new List<TotalFilesWithCondition>();

                dr.FilesCountWithSpecificCondition.Add(new TotalFilesWithCondition
                {
                    ConditionName = "Less 10Mb",
                    FilesCount =
                        HDDInspector.FilesCountWithCondition(x => x.Length / 1048576 <= 10,
                            new DirectoryInfo(dr.DirPath))
                });

                dr.FilesCountWithSpecificCondition.Add(new TotalFilesWithCondition
                {
                    ConditionName = "10Mb - 50Mb",
                    FilesCount =
                        HDDInspector.FilesCountWithCondition(x => x.Length / 1048576 > 10 && x.Length / 1048576 <= 50,
                            new DirectoryInfo(dr.DirPath))
                });

                dr.FilesCountWithSpecificCondition.Add(new TotalFilesWithCondition
                {
                    ConditionName = "More 100Mb",
                    FilesCount =
                        HDDInspector.FilesCountWithCondition(x => x.Length / 1048576 >= 100,
                            new DirectoryInfo(dr.DirPath))
                });
                return dr;
            }
            else
            {
                return "{\"DirPath\":\"Error\", \"OriginalPath\":\"Error\"," +
                       " \"Message\":\"Syntax error or directory doesn't exists. Check out input parameters\"," +
                       " \"PassedParameter\":\"" + dir_path + "\"}";
            }
        }

        [HttpGet]
        public object GetParentByPath(string parentOf)
        {
            if (Directory.Exists(parentOf))
            {
                if (Directory.GetParent(parentOf) != null)
                {
                    DirectoryContent dr = new DirectoryContent(Directory.GetParent(parentOf).FullName);
                    dr.FilesCountWithSpecificCondition = new List<TotalFilesWithCondition>();

                    dr.FilesCountWithSpecificCondition.Add(new TotalFilesWithCondition
                    {
                        ConditionName = "Less 10Mb",
                        FilesCount =
                            HDDInspector.FilesCountWithCondition(x => x.Length/1048576 <= 10,
                                new DirectoryInfo(dr.DirPath))
                    });

                    dr.FilesCountWithSpecificCondition.Add(new TotalFilesWithCondition
                    {
                        ConditionName = "10Mb - 50Mb",
                        FilesCount =
                            HDDInspector.FilesCountWithCondition(x => x.Length/1048576 > 10 && x.Length/1048576 <= 50,
                                new DirectoryInfo(dr.DirPath))
                    });

                    dr.FilesCountWithSpecificCondition.Add(new TotalFilesWithCondition
                    {
                        ConditionName = "More 100Mb",
                        FilesCount =
                            HDDInspector.FilesCountWithCondition(x => x.Length/1048576 >= 100,
                                new DirectoryInfo(dr.DirPath))
                    });
                    return dr;
                }
                else
                    return new RequestError(){ErrorMessage = "", OpenDriveSelectionDlg = true};
            }
            else
            {
                return "{\"DirPath\":\"Error\", \"OriginalPath\":\"Error\"," +
                       " \"Message\":\"Syntax error or directory doesn't exists. Check out input parameters\"," +
                       " \"PassedParameter\":\"" + parentOf + "\"}";
            }
        }
    }
}

