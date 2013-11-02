using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Brienz.DB;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace Brienz.ViewModel
{
    public class MagneticViewModel : ViewModelBase
    {
        BrienzDataAccess DBA;
        public MagneticViewModel()
        {
            DBA = new BrienzDataAccess();
        }
        public void SetName(string filePath, string fileName)
        {
            FileName = fileName;
            FolderName = filePath;
        }
        public void SaveFileProcessStatus()
        {
            FileProcessHistory FileHisotry = new FileProcessHistory();
            FileHisotry.FileName = FileName;
            FileHisotry.FileFolder = FolderName;
            FileHisotry.OpenTime = DateTime.Now;
            FileHisotry.CloseTime = DateTime.Now;
            FileHisotry.BookMark = BookMark;
            FileHisotry.FileGuid = Guid.NewGuid();
            DBA.SaveFileProcessHistory(FileHisotry);
        }
        
        public List<FileProcessStructure> GetAllFileProcessHistory(string filePath)
        {
            List<FileProcessStructure> fileProcessStatus = new List<FileProcessStructure>();
            List<FileProcessHistory> HistoryCollction = DBA.GetAllFileProcessHistory(filePath);
            foreach (FileProcessHistory index in HistoryCollction)
            {
                fileProcessStatus.Add(new FileProcessStructure { FileName = index.FileName, FileFolder = index.FileFolder, OpenTime = index.OpenTime ?? DateTime.Now, CloseTime = index.CloseTime ?? DateTime.Now, BookMark = index.BookMark });
            }
            return fileProcessStatus;
        }
        #region property
        private string _fileName;
        public string FileName
        {
            get
            {

                return _fileName;
            }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    base.OnPropertyChanged("FileName");
                }
            }
        }
        private string _folderName;
        public string FolderName
        {
            get
            {

                return _folderName;
            }
            set
            {
                if (_folderName != value)
                {
                    _folderName = value;
                    base.OnPropertyChanged("FolderName");
                }
            }
        }
        private string _bookMark;
        public string BookMark
        {
            get
            {
                return _bookMark;
            }
            set
            {
                if (_bookMark != value)
                {
                    _bookMark = value;
                    base.OnPropertyChanged("BookMark");
                }
            }
        }
        #endregion
    }
}
