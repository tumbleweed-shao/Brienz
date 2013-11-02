using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Brienz.DB;
using System.Windows.Controls;

namespace Brienz.ViewModel
{
    public class LearnFromItViewModel:ViewModelBase
    {
        BrienzDataAccess access;
        public LearnFromItViewModel()
        {
            access = new BrienzDataAccess();
        }
        private string innerContent;
        public string InnerContent
        {
            get { return innerContent; }
            set
            {
                innerContent = value;
                base.OnPropertyChanged("InnerContent");
            }
        }
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
        private string p_DocumentXaml;
        public string DocumentXaml
        {
            get { return p_DocumentXaml; }

            set
            {
                p_DocumentXaml = value;
                base.OnPropertyChanged("DocumentXaml");
            }
        }
        private ComboBoxItem severity;
        public ComboBoxItem Severity
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
        public bool DeleteAlert(Guid AlertID)
        {
            return access.DeleteAlert(AlertID);
        }
       
        public bool SaveAlert()
        {
            BrienzAlert Alerts = new BrienzAlert();
            Alerts.AlertID = Guid.NewGuid();
            Alerts.AlertSubject = this.AlertSubject;
            Alerts.AlertContent = this.DocumentXaml;
            Alerts.AlertSeverity = this.Severity.Content as string;
            Alerts.AlertTime = DateTime.Now;
            Alerts.Alert_Tag = this.Alert_Tag;
            int result = access.SaveAlert(Alerts);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateAlert(Guid alertID)
        {
            BrienzAlert Alerts = access.GetAlertByAlertID(alertID);
            Alerts.AlertSubject = this.AlertSubject;
            Alerts.AlertContent = this.DocumentXaml;
            Alerts.AlertSeverity = this.Severity.Content as string;
            Alerts.AlertTime = DateTime.Now;
            Alerts.Alert_Tag = this.Alert_Tag;
            int result = access.UpdateAlert(Alerts);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public AlertStructure GetAlertByAlertID(Guid AlertID)
        {
            AlertStructure AlertStr = new AlertStructure();
           BrienzAlert Alert = access.GetAlertByAlertID(AlertID);
           AlertStr.AlertID = Alert.AlertID;
           AlertStr.AlertSubject = Alert.AlertSubject;
           AlertStr.Alert_Tag = Alert.Alert_Tag;
           AlertStr.Severity = Alert.AlertSeverity;
           AlertStr.AlertReason = Alert.AlertReason;
           AlertStr.AlertContent = Alert.AlertContent;
           return AlertStr; 
        }
    }
}
