using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brienz.ViewModel
{
    public class AlertStructure:ViewModelBase
    {
        private Guid alertID;
        public Guid AlertID
        {
            get { return alertID; }
            set
            {
                alertID = value;
                base.OnPropertyChanged("AlertID");
            }
        }
        private string alertContent;
        public string AlertContent
        {
            get { return alertContent; }
            set
            {
                alertContent = value;
                base.OnPropertyChanged("AlertContent");
            }
        }
        private DateTime alertTime;
        public DateTime AlertTime
        {
            get { return alertTime; }
            set
            {
                alertTime = value;
                base.OnPropertyChanged("AlertTime");
            }
        }
        private string alert_Tag;
        public string Alert_Tag
        {
            get { return alert_Tag; }
            set
            {
                alert_Tag = value;
                base.OnPropertyChanged("Alert_Tag");
            }
        }
        private string alertsubject;
        public string AlertSubject
        {
            get { return alertsubject; }
            set
            {
                alertsubject = value;
                base.OnPropertyChanged("AlertSubject");
            }
        }
        private string alertReason;
        public string AlertReason
        {
            get { return alertReason; }
            set
            {
                alertReason = value;
                base.OnPropertyChanged("AlertReason");
            }
        }
        private string severity;
        public string Severity
        {
            get { return severity; }
            set
            {
                severity = value;
                base.OnPropertyChanged("Severity");
            }
        }
        public string AlertOpenLink
        {
            get { return "Edit"; }
        }
        public string DeleteAlertLink
        {
            get { return "Delete"; }
        }
    }
}
