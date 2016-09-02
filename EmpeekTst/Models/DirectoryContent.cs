using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Services.DriveServices;

namespace EmpeekTst.Models
{
    public class TotalFilesWithCondition
    {
        public string ConditionName { get; set; }
        public uint FilesCount { get; set; }
    }

    public class DirectoryContent
    {
        public string DirPath { get; set; } // Represents path to current directory
        public List<FileInfo> Files { get { return HDDInspector.GetFiles(new DirectoryInfo(DirPath)); } } // Contains all files in current directory
        public List<DirectoryInfo> Directories
        {
            get { return HDDInspector.GetDirictories(new DirectoryInfo(DirPath)); }
        } // Contains all dirs in current dir
        public List<TotalFilesWithCondition> FilesCountWithSpecificCondition { get; set; } // Contains all specific conditions as string and count of files with these conds.

        public override string ToString()
        {
            return DirPath;
        }
    }
}