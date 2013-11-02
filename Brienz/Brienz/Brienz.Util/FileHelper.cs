using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Brienz.Util
{
    public class FileHelper
    {
        public static string GetRootPath ()
        {
            LogEntry le = new LogEntry();
            string[] AllFolders;
            string RightPath = "";
            string ParentFolder = "";
            string currentDir = Directory.GetCurrentDirectory();
            //currentDir = @"F:\Debug";
            if (!Directory.Exists(currentDir)) throw new Exception("Cannot find related directory, please check ");
            DirectoryInfo d = new DirectoryInfo(currentDir);
            Logger.Writer.Write(currentDir);
            if (d.Parent == null)
            {
                AllFolders = Directory.GetDirectories(currentDir);
            }
            else
            {
                ParentFolder = Directory.GetParent(currentDir).FullName;
                DirectoryInfo dr = new DirectoryInfo(ParentFolder);
                if (dr.Parent == null)
                {
                    AllFolders = Directory.GetDirectories(ParentFolder);
                    ParentFolder = ParentFolder.Replace(@"\", "");
                }
                else
                {
                    AllFolders = Directory.GetDirectories(ParentFolder);
                }
            }
            bool isRightFolder = false;
            foreach (string index in AllFolders)
            {
                if (index.ToUpper().Contains("ROOT"))
                {
                    isRightFolder = true;
                    RightPath = ParentFolder + @"\Root";
                    break;
                }
            }
            Logger.Writer.Write("RightPath" + RightPath);
            return RightPath;

        }
        public static string GetAbsolutePathByXmlTag(string XMLFolderName)
        {
           return  GetRootPath() + @"\" + XMLFolderName;
        }
        public static bool UpdateFileInfoIntoXML(string filename, string foldername, FileProcessStatusEnum status)
        {
            try
            {
                string absoluteFilePath = GetRootPath() + "\\"+ foldername +"\\"+ "fi.b";
                XmlDocument XD = new XmlDocument();
                if (!File.Exists(absoluteFilePath))
                {
                    XmlNode xmlnode = XD.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                    XD.AppendChild(xmlnode);
                    XmlElement Root = XD.CreateElement("BrienzFileInfo");
                    XD.AppendChild(Root);
                    XD.Save(absoluteFilePath);
                }
                XD.Load(absoluteFilePath);
                if (XD.SelectSingleNode("BrienzFileInfo/FileStatus[@FileName='" + filename + "']") == null)
                {
                    XmlNode NodeFolder = XD.CreateNode(XmlNodeType.Element, "FileStatus", "");
                    XmlAttribute AttrFileName = XD.CreateAttribute("FileName");
                    AttrFileName.Value = filename.Replace("&", "&amp;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;");
                    NodeFolder.Attributes.Append(AttrFileName);
                    XmlAttribute AttrFileID = XD.CreateAttribute("FileID");
                    AttrFileID.Value = Guid.NewGuid().ToString("N");
                    NodeFolder.Attributes.Append(AttrFileID);
                    XmlAttribute AttrFileCreatedTime = XD.CreateAttribute("FileCreatedTime");
                    AttrFileCreatedTime.Value = File.GetCreationTime(GetRootPath() + "\\" + foldername + "\\" + filename).ToString();
                    NodeFolder.Attributes.Append(AttrFileCreatedTime);
                    XmlAttribute AttrFolderName = XD.CreateAttribute("FolderName");
                    AttrFolderName.Value = foldername;
                    NodeFolder.Attributes.Append(AttrFolderName);
                    XmlAttribute AttrStatus = XD.CreateAttribute("Status");
                    AttrStatus.Value = status.ToString();
                    NodeFolder.Attributes.Append(AttrStatus);
                    XD.SelectSingleNode("BrienzFileInfo").AppendChild(NodeFolder);
                    XD.Save(absoluteFilePath);
                }
                else
                {
                    XD.SelectSingleNode("BrienzFileInfo/FileStatus[@FileName='" + filename + "']").Attributes["Status"].Value = status.ToString();
                    XD.Save(absoluteFilePath);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
    }
}
