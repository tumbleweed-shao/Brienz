using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.IO;
using System.Windows;
using Brienz.Util;
using Brienz.DB;

namespace Brienz.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        public MainWindowViewModel()
        {
            InitNotificationZoneValue();
            InitDomainNumberValue();
        }

        private string totalFileNumbers;
        public string TotalFileNumbers 
        {
            get { return totalFileNumbers; }
            set
            {
                totalFileNumbers = value;
                base.OnPropertyChanged("TotalFileNumbers");
            }
        }
        private string notStartedFileNumbers;
        public string NotStartedFileNumbers
        {
            get { return notStartedFileNumbers; }
            set
            {
                notStartedFileNumbers = value;
                base.OnPropertyChanged("NotStartedFileNumbers");
            }
        }
        private string ongoingFileNumbers;
        public string OngoingFileNumbers
        {
            get { return ongoingFileNumbers; }
            set
            {
                ongoingFileNumbers = value;
                base.OnPropertyChanged("OngoingFileNumbers");
            }
        }
        private string processedFileNumbers;
        public string ProcessedFileNumbers
        {
            get { return processedFileNumbers; }
            set
            {
                processedFileNumbers = value;
                base.OnPropertyChanged("ProcessedFileNumbers");
            }
        }
        private string pendingFileNumbers;
        public string PendingFileNumbers
        {
            get { return pendingFileNumbers; }
            set
            {
                pendingFileNumbers = value;
                base.OnPropertyChanged("PendingFileNumbers");
            }
        }

        private string emotionCount;
        public string EmotionCount
        {
            get { return emotionCount; }
            set
            {
                emotionCount = value;
                base.OnPropertyChanged("EmotionCount");
            }
        }
        private string familyCount;
        public string FamilyCount
        {
            get { return familyCount; }
            set
            {
                familyCount = value;
                base.OnPropertyChanged("FamilyCount");
            }
        }
        private string jobCount;
        public string JobCount
        {
            get { return jobCount; }
            set
            {
                jobCount = value;
                base.OnPropertyChanged("JobCount");
            }
        }
        private string friendsCount;
        public string FriendsCount
        {
            get { return friendsCount; }
            set
            {
                friendsCount = value;
                base.OnPropertyChanged("FriendsCount");
            }
        }
        private string healthCount;
        public string HealthCount
        {
            get { return healthCount; }
            set
            {
                healthCount = value;
                base.OnPropertyChanged("HealthCount");
            }
        }
        private string lifeCount;
        public string LifeCount
        {
            get { return lifeCount; }
            set
            {
                lifeCount = value;
                base.OnPropertyChanged("LifeCount");
            }
        }

        public ICommand SynchronizeXML
        {
            get
            {
                return new DelegateCommand<string>((para) =>
                {
                    if (para == "ALL")
                    {
                        try
                        {
                            RootArchitect.RootArchitect RA = new RootArchitect.RootArchitect();
                            bool isSuccess = RA.ComposeRootStruct();
                            if (isSuccess) System.Windows.MessageBox.Show("Create xml file successfully.");
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message);
                        }
                    }
                });
            }
        }


        private void InitNotificationZoneValue()
        {
            try
            {
                RootArchitect.RootArchitect RootHelper = new RootArchitect.RootArchitect();
                if (!File.Exists(System.Environment.CurrentDirectory + ConstValue.XMLFileName))
                {
                    bool isSuccess = RootHelper.ComposeRootStruct();
                    if (!isSuccess) return;
                }
                int FileNo = RootHelper.GetFileNumbers(FileProcessStatusEnum.AllStatus);
                TotalFileNumbers = FileNo + "";
                int NotstartNo = RootHelper.GetFileNumbers(FileProcessStatusEnum.NotStart);
                NotStartedFileNumbers = NotstartNo + "";
                int ProcessedNo = RootHelper.GetFileNumbers(FileProcessStatusEnum.Processed);
                ProcessedFileNumbers = ProcessedNo + "";
                int OngoingNo = RootHelper.GetFileNumbers(FileProcessStatusEnum.OnGoing);
                OngoingFileNumbers = OngoingNo + "";
                int PendingNo = RootHelper.GetFileNumbers(FileProcessStatusEnum.Pending);
                PendingFileNumbers = PendingNo + "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Current.Shutdown();
            }
        }
        private void InitDomainNumberValue()
        {
            SixDomainViewModel sdv = new SixDomainViewModel();
            EmotionCount = sdv.GetDomainDataNumber("Emotion") + "";
            FamilyCount = sdv.GetDomainDataNumber("Family") + "";
            JobCount = sdv.GetDomainDataNumber("Job") + "";
            FriendsCount = sdv.GetDomainDataNumber("Friend(SocialIntercourse)") + "";
            HealthCount = sdv.GetDomainDataNumber("Health") + "";
            LifeCount = sdv.GetDomainDataNumber("Live") + "";
        }

        public List<AlertStructure> GetAllAlert()
        {
            BrienzDataAccess db = new BrienzDataAccess();
            List<AlertStructure> result = new List<AlertStructure>();
            List<BrienzAlert> AlertsCollection =  db.GetAllAlerts();
            foreach(BrienzAlert AlertIndex in AlertsCollection)
            {
                result.Add(
                    new AlertStructure{ 
                        AlertID = AlertIndex.AlertID,
                   AlertSubject = AlertIndex.AlertSubject,  
                   Severity = AlertIndex.AlertSeverity,
                AlertContent = AlertIndex.AlertContent,
                AlertReason = AlertIndex.AlertReason,
                Alert_Tag = AlertIndex.Alert_Tag,
                AlertTime = AlertIndex.AlertTime?? DateTime.Now
                });
            }
            return result;
        }
    }
}
