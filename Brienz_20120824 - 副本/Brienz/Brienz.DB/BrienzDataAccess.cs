using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brienz.DB
{
    public class BrienzDataAccess
    {
        
        public BrienzDataAccess()
        {
        }
        public int SaveAction(BrienzAction action)
        {
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                BrienzAction ba = new BrienzAction();
                ba.ActionID = Guid.NewGuid();
                    ba.EndTime = action.EndTime;
                    ba.FromResource = action.FromResource;
                    ba.IsAllDayEvent = action.IsAllDayEvent;
                    ba.Location = action.Location;
                    ba.Priority = action.Priority;
                    ba.StartTime = action.StartTime;
                    ba.Subject = action.Subject;
                    ba.ActionContent = action.ActionContent;
                BrienzEnt.AddToBrienzActions(ba);
                return BrienzEnt.SaveChanges();
            }
        }
        public int UpdateAction(BrienzAction action)
        {
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                BrienzAction ba = BrienzEnt.BrienzActions.FirstOrDefault(c => c.ActionID == action.ActionID);
                ba.ActionID = action.ActionID;
                ba.EndTime = action.EndTime;
                ba.FromResource = action.FromResource;
                ba.IsAllDayEvent = action.IsAllDayEvent;
                ba.Location = action.Location;
                ba.Priority = action.Priority;
                ba.StartTime = action.StartTime;
                ba.Subject = action.Subject;
                ba.ActionContent = action.ActionContent;
                return BrienzEnt.SaveChanges();
            }
        }
        public List<BrienzAction> GetAllAction()
        {
            List<BrienzAction> ActionCollection = new List<BrienzAction>();
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                ActionCollection = BrienzEnt.BrienzActions.ToList();
            }
            return ActionCollection;
        }
        public List<BrienzTag> GetAllTags()
        {
            List<BrienzTag> ActionCollection = new List<BrienzTag>();
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                ActionCollection = BrienzEnt.BrienzTags.ToList();
            }
            return ActionCollection;
        }
        public BrienzAction GetActionByActionID(Guid ActionID)
        {
            BrienzAction perAction = new BrienzAction();
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                perAction = BrienzEnt.BrienzActions.Where(c => c.ActionID == ActionID).FirstOrDefault();
            }
            return perAction;
        }
        public BrienzAlert GetAlertByAlertID(Guid AlertID)
        {
            BrienzAlert perAlert = new BrienzAlert();
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                perAlert = BrienzEnt.BrienzAlerts.Where(c => c.AlertID == AlertID).FirstOrDefault();
            }
            return perAlert;
        }
        public int SaveAlert(BrienzAlert alert)
        {
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                BrienzAlert ba = new BrienzAlert();
                ba.AlertID = Guid.NewGuid();
                ba.AlertSubject = alert.AlertSubject;
                ba.AlertSeverity = alert.AlertSeverity;
                ba.AlertContent = alert.AlertContent;
                ba.AlertTime = alert.AlertTime;
                ba.Alert_Tag = alert.Alert_Tag;
                ba.AlertReason = alert.AlertReason;
                BrienzEnt.AddToBrienzAlerts(ba);
                return BrienzEnt.SaveChanges();
            }
        }
        public bool DeleteAlert(Guid AlertID)
        {
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                BrienzAlert ba = BrienzEnt.BrienzAlerts.FirstOrDefault(C => C.AlertID == AlertID);
                if (ba != null)
                {
                    BrienzEnt.DeleteObject(ba);
                    int result = BrienzEnt.SaveChanges();
                    if (result != -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool DeleteAction(Guid ActionID)
        {
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                BrienzAction ba = BrienzEnt.BrienzActions.FirstOrDefault(C => C.ActionID == ActionID);
                if (ba != null)
                {
                    BrienzEnt.DeleteObject(ba);
                    int result = BrienzEnt.SaveChanges();
                    if (result != -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int UpdateAlert(BrienzAlert alert)
        {
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                BrienzAlert ba = BrienzEnt.BrienzAlerts.FirstOrDefault(c => c.AlertID == alert.AlertID);
                ba.AlertSubject = alert.AlertSubject;
                ba.AlertContent = alert.AlertContent;
                ba.AlertSeverity = alert.AlertSeverity;
                ba.AlertTime = alert.AlertTime;
                ba.Alert_Tag = alert.Alert_Tag;
                ba.AlertReason = alert.AlertReason;
                return BrienzEnt.SaveChanges();
            }
        }
        public List<BrienzAlert> GetAllAlerts()
        {
            List<BrienzAlert> AlertCollection = new List<BrienzAlert>();
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                AlertCollection = BrienzEnt.BrienzAlerts.ToList();
            }
            return AlertCollection;
        }
        public int SaveFileProcessHistory(FileProcessHistory FileHistory)
        {
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                FileProcessHistory ba = new FileProcessHistory();
                ba.ID = Guid.NewGuid();
                ba.FileName = FileHistory.FileName;
                ba.FileFolder = FileHistory.FileFolder;
                ba.OpenTime = FileHistory.OpenTime;
                ba.FileGuid = FileHistory.FileGuid;
                ba.CloseTime = FileHistory.CloseTime;
                ba.BookMark = FileHistory.BookMark;
                BrienzEnt.AddToFileProcessHistories(ba);
                return BrienzEnt.SaveChanges();
            }
        }
        public List<FileProcessHistory> GetAllFileProcessHistory(string filePath)
        {
            List<FileProcessHistory> FileProcessCollection = new List<FileProcessHistory>();
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                FileProcessCollection = BrienzEnt.FileProcessHistories.Where(c => c.FileFolder == filePath).ToList();
            }
            return FileProcessCollection;
        }
        public int SaveTag(BrienzTag tag)
        {
            using (BrienzDBEntities BrienzEnt = new BrienzDBEntities())
            {
                BrienzTag ba = new BrienzTag();
                ba.TagContent = tag.TagContent;
                ba.TagFrom = tag.TagFrom;
                ba.TagID = Guid.NewGuid();
                ba.FileGuid = tag.FileGuid;
                BrienzEnt.AddToBrienzTags(ba);
                return BrienzEnt.SaveChanges();
            }
        }
    }
}
