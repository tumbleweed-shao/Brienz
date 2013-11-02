using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brienz.Util;
using System.ComponentModel;

namespace Brienz.ViewModel
{
    public class ActionStructure : ViewModelBase
    {
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                base.OnPropertyChanged("ID");
            }
        }
        private Guid actionID;
        public Guid ActionID
        {
            get { return actionID; }
            set
            {
                actionID = value;
                base.OnPropertyChanged("ActionID");
            }
        }
        private string subject;
        public string Subject
        {
            get { return subject; }
            set
            {
                subject = value;
                base.OnPropertyChanged("Subject");
            }
        }
        private string location;
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                base.OnPropertyChanged("Location");
            }
        }
        private string fromResource;
        public string FromResource
        {
            get { return fromResource; }
            set
            {
                fromResource = value;
                base.OnPropertyChanged("FromResource");
            }
        }
        private string priority;
        public string Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                base.OnPropertyChanged("Priority");
            }
        }
        private DateTime startTime;
        public DateTime StartTime
        {
            get
            {
                if (startTime == DateTime.MinValue)
                {
                    startTime = DateTime.Now;
                }
                return startTime;
            }
            set
            {
                startTime = value;
                if (startTime == DateTime.MinValue)
                {
                    startTime = DateTime.Now;
                }
                base.OnPropertyChanged("StartTime");
            }
        }
        private DateTime endTime;
        public DateTime EndTime
        {
            get
            {
                if (endTime == DateTime.MinValue)
                {
                    endTime = DateTime.Now;
                }
                return endTime;
            }
            set
            {
                endTime = value;
                base.OnPropertyChanged("EndTime");
            }
        }
        private bool isAllDayEvent;
        public bool IsAllDayEvent
        {
            get { return isAllDayEvent; }
            set
            {
                isAllDayEvent = value;
                TimeEditable = !isAllDayEvent;
                base.OnPropertyChanged("IsAllDayEvent");
                base.OnPropertyChanged("TimeEditable");
            }
        }
        private bool timeEditable;
        public bool TimeEditable
        {
            get { return timeEditable; }
            set
            {
                timeEditable = value;
                base.OnPropertyChanged("TimeEditable");
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
        public string Link
        {
            get { return "Edit"; }
        }
        public string DeleteAction
        {
            get { return "Delete"; }
        }
    }
}
