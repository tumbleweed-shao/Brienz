using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brienz.DB;

namespace Brienz.ViewModel
{
    public class BrienzTagViewModel:ViewModelBase
    {
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
        BrienzDataAccess bda;
        public BrienzTagViewModel()
        {
            bda = new BrienzDataAccess();
        }
        public int SaveTag()
        {
            string[] splitedTag = this.TagContent.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries );
            foreach (string index in splitedTag)
            {
                BrienzTag brizTag = new BrienzTag();
                brizTag.FileGuid = this.FileGuid;
                brizTag.TagContent = index;
                brizTag.TagFrom = "test";
                bda.SaveTag(brizTag);
            }
            return 1;
        }
    }
}
