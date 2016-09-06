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
        public int FilesCount { get; set; }
    }

    public class DirectoryContent
    {
        private readonly string _dirPath;  // Represents path to current directory
        public string DirPath { get { return _dirPath; } }
        public List<FileInfo> Files { get { return HDDInspector.GetFiles(new DirectoryInfo(_dirPath)); } } // Contains all files in current directory
        public List<DirectoryInfo> Directories
        {
            get { return HDDInspector.GetDirictories(new DirectoryInfo(_dirPath)); }
        } // Contains all dirs in current dir
        public List<TotalFilesWithCondition> FilesCountWithSpecificCondition { get; set; } // Contains all specific conditions as string and count of files with these conds.

        public DirectoryContent(string dirPath)
        {
            _dirPath = dirPath;
        }

        public override string ToString()
        {
            return _dirPath;
        }
    }
}