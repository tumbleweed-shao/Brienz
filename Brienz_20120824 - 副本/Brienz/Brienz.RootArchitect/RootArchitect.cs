using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using Brienz.Util;

namespace Brienz.RootArchitect
{
    public class RootArchitect
    {
        string RootPath = "";
        int CountNumber = 0;
        public RootArchitect()
        {
            try
            {
                RootPath = FileHelper.GetRootPath();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        XmlDocument XD = new XmlDocument();
        
        public bool ComposeRootStruct()
        {
            try
            {
                string RootPath = FileHelper.GetRootPath();
                if (RootPath !="")
                {
                    XmlNode xmlnode = XD.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                    XD.AppendChild(xmlnode);
                    XmlElement Root = XD.CreateElement("Brienz");
                    XD.AppendChild(Root);
                    XmlDocument XMLStructure = Traverse(RootPath, Root);
                    XD.Save(ConstValue.XMLFileName.Replace("\\",""));
                    return true;
                }
                return false;
                //else
                //{
                //    throw new Exception("Can't find the Root folder");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetFileNumbers(FileProcessStatusEnum FileStatus)
        {
            CountNumber = 0;
            if (RootPath == "") return CountNumber;
            XmlDocument xd = new XmlDocument();
            xd.Load(System.Environment.CurrentDirectory + ConstValue.XMLFileName);
            XmlNodeList xnList = xd.SelectNodes("/Brienz");
            TraverseNodes(xnList, FileStatus);
            return CountNumber;
        }
        private XmlDocument Traverse(string rootDirectory, XmlNode XNOrignal)
        {
            if (rootDirectory != "")
            {
                DirectoryInfo DirInfo = new DirectoryInfo(rootDirectory);
                XmlDocument XDGetFileStatus = new XmlDocument();
                if (File.Exists(rootDirectory + "\\fi.b"))
                {
                    XDGetFileStatus.Load(rootDirectory + "\\fi.b");
                }
                XmlNode NodeFolder = XD.CreateNode(XmlNodeType.Element, "Folder", "");
                XmlAttribute AttrFolderName = XD.CreateAttribute("FolderName");
                AttrFolderName.Value = DirInfo.Name.Replace("&", "&amp;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;");
                NodeFolder.Attributes.Append(AttrFolderName);
                XNOrignal.AppendChild(NodeFolder);
                foreach (FileInfo FileIndex in DirInfo.GetFiles())
                {
                    if (FilterNonSearchExtension(FileIndex.Extension))
                    {
                        XmlNode XNFile = XD.CreateNode(XmlNodeType.Element, "File", "");
                        XmlAttribute fileAttr = XD.CreateAttribute("FileStatus");
                        if (File.Exists(rootDirectory + "\\fi.b"))
                        {
                            if (XDGetFileStatus.SelectSingleNode("BrienzFileInfo/FileStatus[@FileName='" + FileIndex.Name + "']") != null)
                            {
                                string filestatus = XDGetFileStatus.SelectSingleNode("BrienzFileInfo/FileStatus[@FileName='" + FileIndex.Name + "']").Attributes["Status"].Value;
                                fileAttr.Value = filestatus;
                            }
                            else
                            {
                                fileAttr.Value = FileProcessStatusEnum.NotStart.ToString();
                            }
                        }
                        else
                        {
                            fileAttr.Value = FileProcessStatusEnum.NotStart.ToString();
                        }
                        XNFile.Attributes.Append(fileAttr);
                        XmlAttribute AttrName = XD.CreateAttribute("FileName");
                        AttrName.Value = FileIndex.Name.Replace("&", "&amp;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;");
                        XNFile.Attributes.Append(AttrName);
                        NodeFolder.AppendChild(XNFile);
                    }
                }
                foreach (DirectoryInfo DirIndex in DirInfo.GetDirectories())
                {
                    Traverse(DirIndex.FullName, NodeFolder);
                }
            }
            return XD;
        }
        private void TraverseNodes(XmlNodeList nodes , FileProcessStatusEnum FileProcess)
        {
            foreach (XmlNode node in nodes)
            {
                // Do something with the node.
                if (FileProcess == FileProcessStatusEnum.AllStatus)
                {
                    if (node.Name == "File")
                    {
                        CountNumber++;
                    }
                }
                if (node.Name == "File" && node.Attributes["FileStatus"].Value == FileProcess.ToString())
                {
                    CountNumber++;
                }
                TraverseNodes(node.ChildNodes, FileProcess);
            }
        }
        private bool FilterNonSearchExtension(string fileExtension)
        {
            string FilterValue = System.Configuration.ConfigurationSettings.AppSettings["NonSearchExtension"];
            string[] AllNonSearchableValue = FilterValue.Split('|');
            foreach (string index in AllNonSearchableValue)
            {
                
                if (fileExtension == index)
                {
                    return false;
                }
            }
            return true;
        }

        public void TraverseSearchXMLByNode(XmlNodeList XMLNodes, string SearchedNode)
        {
            
            foreach (XmlNode node in XMLNodes)
            {
                if (!node.HasChildNodes)
                {
                    if (node.InnerText == SearchedNode)
                    {
                        return;
                    }
                }
                TraverseSearchXMLByNode(node.ChildNodes, SearchedNode);
            }
        }
    }
}
