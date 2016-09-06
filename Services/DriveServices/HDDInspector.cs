using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.DriveServices
{
    public static class HDDInspector
    {
        public static DriveInfo[] GetDrives
        {
            get { return DriveInfo.GetDrives(); }
        }

        public static List<DirectoryInfo> GetDirictories(DriveInfo onDrive)
        {
            return !onDrive.IsReady ? null : onDrive.RootDirectory.GetDirectories().ToList<DirectoryInfo>();
        }

        public static List<DirectoryInfo> GetDirictories(DirectoryInfo inDirectory)
        {
            return !inDirectory.Exists ? null : inDirectory.GetDirectories().ToList<DirectoryInfo>();
        }

        public static List<FileInfo> GetFiles(DriveInfo onDrive)
        {
            return !onDrive.IsReady ? null : onDrive.RootDirectory.GetFiles().ToList<FileInfo>();
        }

        public static List<FileInfo> GetFiles(DirectoryInfo inDirectory)
        {
            return !inDirectory.Exists ? null : inDirectory.GetFiles().ToList<FileInfo>();
        }

        public static int FilesCountWithCondition(Func<FileInfo, bool> filePredicate, DirectoryInfo inDirectory)
        {
            if (!inDirectory.Exists)
                return -1;
            
            int res = 0;

            try
            {
                res = inDirectory.GetFiles().Where(filePredicate).ToArray().Length +
                      inDirectory.GetDirectories().Sum(dir => FilesCountWithCondition(filePredicate, dir));
            }
            catch (Exception)
            {
              
            }

            return res;
        }
    }
}