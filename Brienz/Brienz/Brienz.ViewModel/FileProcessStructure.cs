using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brienz.ViewModel
{
    public class FileProcessStructure:ViewModelBase
    {
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                base.OnPropertyChanged("FileName");
            }
        }
        private string fileFolder;
        public string FileFolder
        {
            get { return fileFolder; }
            set
            {
                fileFolder = value;
                base.OnPropertyChanged("FileFolder");
            }
        }
        private DateTime openTime;
        public DateTime OpenTime
        {
            get { return openTime; }
            set
            {
                openTime = value;
                base.OnPropertyChanged("OpenTime");
            }
        }
        private DateTime closeTime;
        public DateTime CloseTime
        {
            get { return closeTime; }
            set
            {
                closeTime = value;
                base.OnPropertyChanged("CloseTime");
            }
        }
        private string bookMark;
        public string BookMark
        {
            get { return bookMark; }
            set
            {
                bookMark = value;
                base.OnPropertyChanged("BookMark");
            }
        }
        private Guid fileGuid;
        public Guid FileGuid
        {
            get { return fileGuid; }
            set
            {
                fileGuid = value;
                base.OnPropertyChanged("FileGuid");
            }
        }
    }
}
