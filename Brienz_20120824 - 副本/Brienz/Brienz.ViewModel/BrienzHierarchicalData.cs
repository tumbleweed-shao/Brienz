using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using Brienz.ViewModel;
using Brienz.Util;

//namespace Brienz.ViewModel
//{
   public  class BrienzHierarchicalData:ViewModelBase
    {
        private string data;
        public string Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged("Data");
                }
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string folderName;
        public string FolderName
        {
            get { return folderName; }
            set
            {
                if (folderName != value)
                {
                    folderName = value;
                    OnPropertyChanged("FolderName");
                }
            }
        }
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }
        private string fileStatus;
        public string FileStatus
        {
            get { return fileStatus; }
            set
            {
                if (fileStatus != value)
                {
                    fileStatus = value;
                    OnPropertyChanged("FileStatus");
                }
            }
        }
        private XmlAttributeCollection attributes;
        public XmlAttributeCollection Attributes
        {
            get { return attributes; }
            set
            {
                if (attributes != value)
                {
                    attributes = value;
                    OnPropertyChanged("Attributes");
                }
            }
        }
        //private List<BrienzHierarchicalData> children;
        //public List<BrienzHierarchicalData> Children
        //{
        //    get { return children; }
        //    set
        //    {
        //        if (children != value)
        //        {
        //            children = value;
        //            OnPropertyChanged("Children");
        //        }
        //    }
        //}
    }
//}
