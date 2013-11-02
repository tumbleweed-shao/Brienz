using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.Xml;
using System.IO;
using Brienz.Util;
using System.Diagnostics;

namespace Brienz.ViewModel
{
    public class BrienzNewItemViewModel:ViewModelBase
    {
        string SelectedFolder {get;set;}
        string WidgetName { get; set; }
        public BrienzNewItemViewModel()
        {
            
        }
        public void SetFolderName(string folderName, string domainName)
        {
            SelectedFolder = folderName;
            WidgetName = domainName;
        }
        private string seletedTab;
        public string SeletedTab
        {
            get
            {
                return seletedTab;
            }
            set
            {
                if (seletedTab != value)
                {
                    seletedTab = value;
                    base.OnPropertyChanged("SeletedTab");
                }
            }
        }
        private string linkTab_URL;
        public string LinkTab_URL
        {
            get
            {
                return linkTab_URL;
            }
            set
            {
                if (linkTab_URL != value)
                {
                    linkTab_URL = value;
                    base.OnPropertyChanged("LinkTab_URL");
                }
            }
        }
        private string linkTab_Name;
        public string LinkTab_Name
        {
            get
            {
                return linkTab_Name;
            }
            set
            {
                if (linkTab_Name != value)
                {
                    linkTab_Name = value;
                    base.OnPropertyChanged("LinkTab_Name");
                }
            }
        }
        private bool isCheckWord;
        public bool IsCheckWord
        {
            get
            {
                return isCheckWord;
            }
            set
            {
                if (isCheckWord != value)
                {
                    isCheckWord = value;
                    base.OnPropertyChanged("IsCheckWord");
                }
            }
        }
        private bool isCheckExcel;
        public bool IsCheckExcel
        {
            get
            {
                return isCheckExcel;
            }
            set
            {
                if (isCheckExcel != value)
                {
                    isCheckExcel = value;
                    base.OnPropertyChanged("IsCheckExcel");
                }
            }
        }
        private bool isCheckTxt;
        public bool IsCheckTxt
        {
            get
            {
                return isCheckTxt;
            }
            set
            {
                if (isCheckTxt != value)
                {
                    isCheckTxt = value;
                    base.OnPropertyChanged("IsCheckTxt");
                }
            }
        }
        private bool isCheckZip;
        public bool IsCheckZip
        {
            get
            {
                return isCheckZip;
            }
            set
            {
                if (isCheckZip != value)
                {
                    isCheckZip = value;
                    base.OnPropertyChanged("IsCheckZip");
                }
            }
        }
        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    base.OnPropertyChanged("FileName");
                }
            }
        }
        public bool SaveNewItem()
        {
            string folderName = SelectedFolder;
            string[] aplitedFolder = new string[0];
            if ((folderName.IndexOf(WidgetName) + WidgetName.Length + 1) < folderName.Length)
            {
                aplitedFolder = folderName.Substring(folderName.IndexOf(WidgetName) + WidgetName.Length + 1).Split('|');
            }
            string hiricalFolder = "";
            foreach (string index in aplitedFolder)
            {
                hiricalFolder += ConstValue.XMLFolderNS;
            }
            XmlDocument xd = new XmlDocument();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + ConstValue.XMLFileName, System.Text.Encoding.GetEncoding("utf-8"));
            xd.Load(sr);
            XmlNode currentNode;
            if (hiricalFolder != "")
            {
                currentNode = xd.SelectSingleNode("/Brienz" + ConstValue.XMLFolderNS + ConstValue.XMLFolderNS + "[@" + ConstValue.XMLFileAttribute_FolderName + "='" + WidgetName + "']" + hiricalFolder + "[@" + ConstValue.XMLFileAttribute_FolderName + "='" + aplitedFolder[aplitedFolder.Length - 1] + "']");
            }
            else
            {
                currentNode = xd.SelectSingleNode("/Brienz" + ConstValue.XMLFolderNS + ConstValue.XMLFolderNS + "[@" + ConstValue.XMLFileAttribute_FolderName + "='" + WidgetName + "']" + "[@" + ConstValue.XMLFileAttribute_FolderName + "='" + WidgetName + "']");
            }
            bool result = false;
            switch (SeletedTab)
            {
                case "Link":
                    
                    
                    XmlDocument DomainDoc = new XmlDocument();
                    urlShortcutToDesktop(LinkTab_Name, LinkTab_URL);
                    result = true;
                    break;
                case "File":
                    if (IsCheckWord)
                    {
                        string deskDir = FileHelper.GetRootPath() + @"\" + SelectedFolder.Replace('|', '\\') + @"\" +  FileName + ".doc";
                        FileStream fs = File.Create(deskDir);
                        fs.Close();
                        Process.Start(deskDir);
                    }
                    else if (IsCheckExcel)
                    {
                        string deskDir = FileHelper.GetRootPath() + @"\" + SelectedFolder.Replace('|', '\\') + @"\" + FileName + ".xls";
                        FileStream fs = File.Create(deskDir);
                        fs.Close();
                        Process.Start(deskDir);
                    }
                    else if (IsCheckTxt)
                    {
                        string deskDir = FileHelper.GetRootPath() + @"\" + SelectedFolder.Replace('|', '\\') + @"\" + FileName + ".txt";
                        FileStream fs = File.Create(deskDir);
                        fs.Close();
                        Process.Start(deskDir);
                    }
                    else if (IsCheckZip)
                    {

                    }
                    result = true;
                    break;
                case "GOGO":
                    result = true;
                    break;
            }
            return result;
        }
        private void urlShortcutToDesktop(string linkName, string linkUrl)
        {
            string deskDir = FileHelper.GetRootPath() + @"\"+ SelectedFolder.Replace('|','\\');
            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=" + linkUrl);
                writer.Flush();
            }
        }
    }
}
