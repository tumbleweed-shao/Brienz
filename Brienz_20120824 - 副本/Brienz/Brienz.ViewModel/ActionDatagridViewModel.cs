using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Brienz.Util;
using System.Xml;
using Brienz.DB;

namespace Brienz.ViewModel
{
    public class ActionDatagridViewModel : ViewModelBase
    {
        ObservableCollection<ActionStructure> actionList;
        BrienzDataAccess access;
        public ActionDatagridViewModel()
        {
            actionList = new ObservableCollection<ActionStructure>();
            GetActionList();
        }

        public void GetActionList()
        {
            access = new BrienzDataAccess();
            
            List<BrienzAction> actionCollection = access.GetAllAction();
            int number = 0;
            foreach (BrienzAction ActionIndex in actionCollection.OrderBy(c=>c.Priority))
            {
                actionList.Add(new ActionStructure
                {
                    ID = ++number,
                    ActionID = ActionIndex.ActionID,
                    Subject = ActionIndex.Subject,
                    EndTime = ActionIndex.EndTime ?? DateTime.Now,
                    FromResource = ActionIndex.FromResource,
                    IsAllDayEvent = ActionIndex.IsAllDayEvent ?? false,
                    Location = ActionIndex.Location,
                    Priority = ActionIndex.Priority,
                    DocumentXaml = ActionIndex.ActionContent,
                    StartTime = ActionIndex.StartTime ?? DateTime.Now
                });
            }
        }
        
        //public DataGrid ActionDataGrid
        //{
        //    get
        //    {
        //        return getDataGrid();
        //    }
        //}
        //private DataGrid getDataGrid()
        //{
        //    DataGrid dg = new DataGrid();
        //    dg.DataContext = new NewAction();

        //    return dg;
        //}
        //public ICommand UpdateParentWindowActionGrid 
        //{
        //    get
        //    {
        //        return new DelegateCommand(() => {
        //            new NewAction();
        //        });
        //    }
        //}
        public void SaveActionUpdateParentWindowActionGrid()
        {
            BrienzAction newAction = new BrienzAction();
            newAction.ActionContent = this.DocumentXaml;
            newAction.EndTime = this.EndTime;
            newAction.FromResource = this.FromResource;
            newAction.IsAllDayEvent = this.IsAllDayEvent;
            newAction.Location = this.Location;
            newAction.Priority = this.Priority.Content as string;
            newAction.StartTime = this.StartTime;
            newAction.Subject = this.Subject;
            access.SaveAction(newAction);
            actionList.Add(new ActionStructure
            {
                //ActionID = newAction.ActionID,
                Subject = newAction.Subject,
                EndTime = newAction.EndTime ?? DateTime.Now,
                FromResource = newAction.FromResource,
                IsAllDayEvent = newAction.IsAllDayEvent ?? false,
                Location = newAction.Location,
                Priority = newAction.Priority,
                DocumentXaml = newAction.ActionContent,
                StartTime = newAction.StartTime ?? DateTime.Now
            });
        }
        public void DeleteAction(Guid ActionID)
        {
            access.DeleteAction(ActionID);
        }
        public int UpdateActionUpdateParentWindowActionGridByID(Guid ActionID)
        {
            access = new BrienzDataAccess();
            BrienzAction GetAction = access.GetActionByActionID(ActionID);
            GetAction.EndTime = this.EndTime;
            GetAction.ActionContent = this.DocumentXaml;
            GetAction.FromResource = this.FromResource;
            GetAction.Location = this.Location;
            GetAction.IsAllDayEvent = this.IsAllDayEvent;
            GetAction.Priority = this.Priority.Content as string;
            GetAction.StartTime = this.StartTime;
            GetAction.Subject = this.Subject;
            return  access.UpdateAction(GetAction);

        }
        public ActionStructure GetActionByID(Guid ActionID)
        {
            access = new BrienzDataAccess();
            ActionStructure actStr = new ActionStructure();
            BrienzAction GetAction = access.GetActionByActionID(ActionID);
            actStr.ActionID = GetAction.ActionID;
            actStr.EndTime = GetAction.EndTime??DateTime.Now;
            actStr.FromResource = GetAction.FromResource;
            actStr.DocumentXaml = GetAction.ActionContent;
            //TODO:
            actStr.Location = GetAction.Location;
            actStr.IsAllDayEvent = GetAction.IsAllDayEvent?? false;
            actStr.Priority = GetAction.Priority;
            actStr.StartTime = GetAction.StartTime?? DateTime.Now;
            actStr.Subject = GetAction.Subject;
            return actStr;
        }
        private void SaveToXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);// Create the root element
            XmlElement root = doc.CreateElement("Library");
            doc.AppendChild(root);
            XmlElement subject = doc.CreateElement("Subject");
            subject.InnerText = this.Subject;
            root.AppendChild(subject);
            XmlElement location = doc.CreateElement("Location");
            location.InnerText = this.Location;
            root.AppendChild(location);
            XmlElement fromResource = doc.CreateElement("FromResource");
            fromResource.InnerText = this.FromResource;
            root.AppendChild(fromResource);
            XmlElement priority = doc.CreateElement("Priority");
            priority.InnerText = this.Priority.ToString();
            root.AppendChild(priority);
            XmlElement startTime = doc.CreateElement("StartTime");
            startTime.InnerText = this.StartTime.ToLocalTime().ToString();
            root.AppendChild(startTime);
            XmlElement endTime = doc.CreateElement("EndTime");
            endTime.InnerText = this.EndTime.ToLocalTime().ToString();
            root.AppendChild(endTime);
            XmlElement isAllDayEvent = doc.CreateElement("IsAllDayEvent");
            isAllDayEvent.InnerText = this.IsAllDayEvent.ToString();
            root.AppendChild(isAllDayEvent);
            //XmlElement innerHTML = doc.CreateElement("InnerContent");
            //innerHTML.InnerText = this.InnerContent.ToString();
            //root.AppendChild(innerHTML);
            //doc.Save("test.xml");
        }
        #region Property Region
        
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
        private ComboBoxItem priority;
        public ComboBoxItem Priority
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
            get {
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
                base.OnPropertyChanged("IsAllDayEvent");
                base.OnPropertyChanged("TimeEditable");
            }
        }
        private bool timeEditable = true;
        public bool TimeEditable
        {
            get 
            {
                if (IsAllDayEvent)
                {
                    return !IsAllDayEvent;
                }
                return timeEditable;
            }
            set
            {
                timeEditable = value;
                base.OnPropertyChanged("TimeEditable");
            }
        }
        private string p_DocumentXaml;
        public string DocumentXaml
        {
            get {

                return p_DocumentXaml; 
            }
            set
            {
                p_DocumentXaml = value;
                base.OnPropertyChanged("DocumentXaml");
            }
        }

        private bool isCompleteChecked;
        public bool IsCompleteChecked
        {
            get {
                if (isCompleteChecked)
                {
                    IsSubjectEnabled = false;
                    IsLocationEnabled = false;
                    IsResourceEnabled = false;
                    IsPriorityEnabled = false;
                    IsStartTimeEnabled = false;
                    IsEndTimeEnabled = false;
                    IsAllDayEventEnabled = false;
                    IsInnerContentEnabled = false;
                    TimeEditable = false;
                }
                else
                {
                    IsSubjectEnabled = true;
                    IsLocationEnabled = true;
                    IsResourceEnabled = true;
                    IsPriorityEnabled = true;
                    IsStartTimeEnabled = true;
                    IsEndTimeEnabled = true;
                    IsAllDayEventEnabled = true;
                    IsInnerContentEnabled = true;
                    TimeEditable = true;
                }
                return isCompleteChecked; 
            }
            set
            {
                isCompleteChecked = value;
                base.OnPropertyChanged("IsCompleteChecked");
            }
        }
        private bool isSubjectEnabled = true;
        public bool IsSubjectEnabled
        {
            get
            {
                return isSubjectEnabled;
            }
            set
            {
                isSubjectEnabled = value;
                base.OnPropertyChanged("IsSubjectEnabled");
            }
        }
        private bool isLocationEnabled = true;
        public bool IsLocationEnabled
        {
            get
            {
                return isLocationEnabled;
            }
            set
            {
                isLocationEnabled = value;
                base.OnPropertyChanged("IsLocationEnabled");
            }
        }
        private bool isResourceEnabled = true;
        public bool IsResourceEnabled
        {
            get
            {
                return isResourceEnabled;
            }
            set
            {
                isResourceEnabled = value;
                base.OnPropertyChanged("IsResourceEnabled");
            }
        }
        private bool isPriorityEnabled = true;
        public bool IsPriorityEnabled
        {
            get
            {
                return isPriorityEnabled;
            }
            set
            {
                isPriorityEnabled = value;
                base.OnPropertyChanged("IsPriorityEnabled");
            }
        }
        private bool isStartTimeEnabled = true;
        public bool IsStartTimeEnabled
        {
            get
            {
                return isStartTimeEnabled;
            }
            set
            {
                isStartTimeEnabled = value;
                base.OnPropertyChanged("IsStartTimeEnabled");
            }
        }
        private bool isEndTimeEnabled = true;
        public bool IsEndTimeEnabled
        {
            get
            {
                return isEndTimeEnabled;
            }
            set
            {
                isEndTimeEnabled = value;
                base.OnPropertyChanged("IsEndTimeEnabled");
            }
        }
        private bool isAllDayEventEnabled = true;
        public bool IsAllDayEventEnabled
        {
            get
            {
                return isAllDayEventEnabled;
            }
            set
            {
                isAllDayEventEnabled = value;
                base.OnPropertyChanged("IsAllDayEventEnabled");
            }
        }
        private bool isInnerContentEnabled = true;
        public bool IsInnerContentEnabled
        {
            get
            {
                return isInnerContentEnabled;
            }
            set
            {
                isInnerContentEnabled = value;
                base.OnPropertyChanged("IsInnerContentEnabled");
            }
        }
        #endregion

        public ObservableCollection<ActionStructure> ActionList
        {
            get
            {
                return actionList;
            }
            set
            {
                if (value != actionList)
                {
                    actionList = value;
                    base.OnPropertyChanged("ActionList");
                }
            }
        }
    }
    
}
