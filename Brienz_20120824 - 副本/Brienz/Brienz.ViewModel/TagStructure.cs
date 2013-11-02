using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brienz.ViewModel
{
    public class TagStructure: ViewModelBase
    {
        private Guid tagID;
        public Guid TagID
        {
            get { return tagID; }
            set
            {
                tagID = value;
                base.OnPropertyChanged("TagID");
            }
        }
        private string tagContent;
        public string TagContent
        {
            get { return tagContent; }
            set
            {
                tagContent = value;
                base.OnPropertyChanged("TagContent");
            }
        }
        private string tagFromSource;
        public string TagFromSource
        {
            get { return tagFromSource; }
            set
            {
                tagFromSource = value;
                base.OnPropertyChanged("TagFromSource");
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
