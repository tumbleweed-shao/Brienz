using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Brienz.Util
{
    public class ConstValue
    {
        public static string XMLFileName = @"\Index.xml";
        public static string XMLUpdatedFolder
        {
            get
            {
                if (Directory.Exists("Updated"))
                    return "Updated";
                else
                {
                    Directory.CreateDirectory("Updated");
                    return "Updated";
                }
            }
        }
        public static string XMLFolderNS = "/Folder";
        public static string FolderNS = "Folder";
        public static string FileNS = "File";
        public static string XMLFileAttribute_FolderName = "FolderName";
        public static string XMLFileAttribute_FileName = "FileName";
        public static string XMLFileAttribute_FileStatus = "FileStatus";
        public static string XMLROOTFOLDERNAME = "/Root";
        public static string ROOTFOLDERNAME = @"\Root";
        public static string DISKNAME = "";
       
    }
}
