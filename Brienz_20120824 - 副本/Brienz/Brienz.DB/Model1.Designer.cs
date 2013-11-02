﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace Brienz.DB
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class BrienzDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new BrienzDBEntities object using the connection string found in the 'BrienzDBEntities' section of the application configuration file.
        /// </summary>
        public BrienzDBEntities() : base("name=BrienzDBEntities", "BrienzDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BrienzDBEntities object.
        /// </summary>
        public BrienzDBEntities(string connectionString) : base(connectionString, "BrienzDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BrienzDBEntities object.
        /// </summary>
        public BrienzDBEntities(EntityConnection connection) : base(connection, "BrienzDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BrienzAction> BrienzActions
        {
            get
            {
                if ((_BrienzActions == null))
                {
                    _BrienzActions = base.CreateObjectSet<BrienzAction>("BrienzActions");
                }
                return _BrienzActions;
            }
        }
        private ObjectSet<BrienzAction> _BrienzActions;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BrienzAlert> BrienzAlerts
        {
            get
            {
                if ((_BrienzAlerts == null))
                {
                    _BrienzAlerts = base.CreateObjectSet<BrienzAlert>("BrienzAlerts");
                }
                return _BrienzAlerts;
            }
        }
        private ObjectSet<BrienzAlert> _BrienzAlerts;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BrienzTag> BrienzTags
        {
            get
            {
                if ((_BrienzTags == null))
                {
                    _BrienzTags = base.CreateObjectSet<BrienzTag>("BrienzTags");
                }
                return _BrienzTags;
            }
        }
        private ObjectSet<BrienzTag> _BrienzTags;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<FileProcessHistory> FileProcessHistories
        {
            get
            {
                if ((_FileProcessHistories == null))
                {
                    _FileProcessHistories = base.CreateObjectSet<FileProcessHistory>("FileProcessHistories");
                }
                return _FileProcessHistories;
            }
        }
        private ObjectSet<FileProcessHistory> _FileProcessHistories;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the BrienzActions EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBrienzActions(BrienzAction brienzAction)
        {
            base.AddObject("BrienzActions", brienzAction);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the BrienzAlerts EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBrienzAlerts(BrienzAlert brienzAlert)
        {
            base.AddObject("BrienzAlerts", brienzAlert);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the BrienzTags EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBrienzTags(BrienzTag brienzTag)
        {
            base.AddObject("BrienzTags", brienzTag);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the FileProcessHistories EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToFileProcessHistories(FileProcessHistory fileProcessHistory)
        {
            base.AddObject("FileProcessHistories", fileProcessHistory);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BrienzDBModel", Name="BrienzAction")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class BrienzAction : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new BrienzAction object.
        /// </summary>
        /// <param name="actionID">Initial value of the ActionID property.</param>
        public static BrienzAction CreateBrienzAction(global::System.Guid actionID)
        {
            BrienzAction brienzAction = new BrienzAction();
            brienzAction.ActionID = actionID;
            return brienzAction;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                OnSubjectChanging(value);
                ReportPropertyChanging("Subject");
                _Subject = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Subject");
                OnSubjectChanged();
            }
        }
        private global::System.String _Subject;
        partial void OnSubjectChanging(global::System.String value);
        partial void OnSubjectChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Location
        {
            get
            {
                return _Location;
            }
            set
            {
                OnLocationChanging(value);
                ReportPropertyChanging("Location");
                _Location = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Location");
                OnLocationChanged();
            }
        }
        private global::System.String _Location;
        partial void OnLocationChanging(global::System.String value);
        partial void OnLocationChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                OnPriorityChanging(value);
                ReportPropertyChanging("Priority");
                _Priority = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Priority");
                OnPriorityChanged();
            }
        }
        private global::System.String _Priority;
        partial void OnPriorityChanging(global::System.String value);
        partial void OnPriorityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FromResource
        {
            get
            {
                return _FromResource;
            }
            set
            {
                OnFromResourceChanging(value);
                ReportPropertyChanging("FromResource");
                _FromResource = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FromResource");
                OnFromResourceChanged();
            }
        }
        private global::System.String _FromResource;
        partial void OnFromResourceChanging(global::System.String value);
        partial void OnFromResourceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsAllDayEvent
        {
            get
            {
                return _IsAllDayEvent;
            }
            set
            {
                OnIsAllDayEventChanging(value);
                ReportPropertyChanging("IsAllDayEvent");
                _IsAllDayEvent = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsAllDayEvent");
                OnIsAllDayEventChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsAllDayEvent;
        partial void OnIsAllDayEventChanging(Nullable<global::System.Boolean> value);
        partial void OnIsAllDayEventChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                OnStartTimeChanging(value);
                ReportPropertyChanging("StartTime");
                _StartTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("StartTime");
                OnStartTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _StartTime;
        partial void OnStartTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnStartTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                OnEndTimeChanging(value);
                ReportPropertyChanging("EndTime");
                _EndTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EndTime");
                OnEndTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _EndTime;
        partial void OnEndTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnEndTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ActionID
        {
            get
            {
                return _ActionID;
            }
            set
            {
                if (_ActionID != value)
                {
                    OnActionIDChanging(value);
                    ReportPropertyChanging("ActionID");
                    _ActionID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ActionID");
                    OnActionIDChanged();
                }
            }
        }
        private global::System.Guid _ActionID;
        partial void OnActionIDChanging(global::System.Guid value);
        partial void OnActionIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ActionContent
        {
            get
            {
                return _ActionContent;
            }
            set
            {
                OnActionContentChanging(value);
                ReportPropertyChanging("ActionContent");
                _ActionContent = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ActionContent");
                OnActionContentChanged();
            }
        }
        private global::System.String _ActionContent;
        partial void OnActionContentChanging(global::System.String value);
        partial void OnActionContentChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BrienzDBModel", Name="BrienzAlert")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class BrienzAlert : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new BrienzAlert object.
        /// </summary>
        /// <param name="alertID">Initial value of the AlertID property.</param>
        public static BrienzAlert CreateBrienzAlert(global::System.Guid alertID)
        {
            BrienzAlert brienzAlert = new BrienzAlert();
            brienzAlert.AlertID = alertID;
            return brienzAlert;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid AlertID
        {
            get
            {
                return _AlertID;
            }
            set
            {
                if (_AlertID != value)
                {
                    OnAlertIDChanging(value);
                    ReportPropertyChanging("AlertID");
                    _AlertID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("AlertID");
                    OnAlertIDChanged();
                }
            }
        }
        private global::System.Guid _AlertID;
        partial void OnAlertIDChanging(global::System.Guid value);
        partial void OnAlertIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AlertContent
        {
            get
            {
                return _AlertContent;
            }
            set
            {
                OnAlertContentChanging(value);
                ReportPropertyChanging("AlertContent");
                _AlertContent = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AlertContent");
                OnAlertContentChanged();
            }
        }
        private global::System.String _AlertContent;
        partial void OnAlertContentChanging(global::System.String value);
        partial void OnAlertContentChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> AlertTime
        {
            get
            {
                return _AlertTime;
            }
            set
            {
                OnAlertTimeChanging(value);
                ReportPropertyChanging("AlertTime");
                _AlertTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AlertTime");
                OnAlertTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _AlertTime;
        partial void OnAlertTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnAlertTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Alert_Tag
        {
            get
            {
                return _Alert_Tag;
            }
            set
            {
                OnAlert_TagChanging(value);
                ReportPropertyChanging("Alert_Tag");
                _Alert_Tag = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Alert_Tag");
                OnAlert_TagChanged();
            }
        }
        private global::System.String _Alert_Tag;
        partial void OnAlert_TagChanging(global::System.String value);
        partial void OnAlert_TagChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AlertReason
        {
            get
            {
                return _AlertReason;
            }
            set
            {
                OnAlertReasonChanging(value);
                ReportPropertyChanging("AlertReason");
                _AlertReason = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AlertReason");
                OnAlertReasonChanged();
            }
        }
        private global::System.String _AlertReason;
        partial void OnAlertReasonChanging(global::System.String value);
        partial void OnAlertReasonChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AlertSubject
        {
            get
            {
                return _AlertSubject;
            }
            set
            {
                OnAlertSubjectChanging(value);
                ReportPropertyChanging("AlertSubject");
                _AlertSubject = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AlertSubject");
                OnAlertSubjectChanged();
            }
        }
        private global::System.String _AlertSubject;
        partial void OnAlertSubjectChanging(global::System.String value);
        partial void OnAlertSubjectChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AlertSeverity
        {
            get
            {
                return _AlertSeverity;
            }
            set
            {
                OnAlertSeverityChanging(value);
                ReportPropertyChanging("AlertSeverity");
                _AlertSeverity = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AlertSeverity");
                OnAlertSeverityChanged();
            }
        }
        private global::System.String _AlertSeverity;
        partial void OnAlertSeverityChanging(global::System.String value);
        partial void OnAlertSeverityChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BrienzDBModel", Name="BrienzTag")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class BrienzTag : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new BrienzTag object.
        /// </summary>
        /// <param name="tagID">Initial value of the TagID property.</param>
        public static BrienzTag CreateBrienzTag(global::System.Guid tagID)
        {
            BrienzTag brienzTag = new BrienzTag();
            brienzTag.TagID = tagID;
            return brienzTag;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid TagID
        {
            get
            {
                return _TagID;
            }
            set
            {
                if (_TagID != value)
                {
                    OnTagIDChanging(value);
                    ReportPropertyChanging("TagID");
                    _TagID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("TagID");
                    OnTagIDChanged();
                }
            }
        }
        private global::System.Guid _TagID;
        partial void OnTagIDChanging(global::System.Guid value);
        partial void OnTagIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TagContent
        {
            get
            {
                return _TagContent;
            }
            set
            {
                OnTagContentChanging(value);
                ReportPropertyChanging("TagContent");
                _TagContent = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TagContent");
                OnTagContentChanged();
            }
        }
        private global::System.String _TagContent;
        partial void OnTagContentChanging(global::System.String value);
        partial void OnTagContentChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Guid> FileGuid
        {
            get
            {
                return _FileGuid;
            }
            set
            {
                OnFileGuidChanging(value);
                ReportPropertyChanging("FileGuid");
                _FileGuid = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FileGuid");
                OnFileGuidChanged();
            }
        }
        private Nullable<global::System.Guid> _FileGuid;
        partial void OnFileGuidChanging(Nullable<global::System.Guid> value);
        partial void OnFileGuidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TagFrom
        {
            get
            {
                return _TagFrom;
            }
            set
            {
                OnTagFromChanging(value);
                ReportPropertyChanging("TagFrom");
                _TagFrom = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TagFrom");
                OnTagFromChanged();
            }
        }
        private global::System.String _TagFrom;
        partial void OnTagFromChanging(global::System.String value);
        partial void OnTagFromChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BrienzDBModel", Name="FileProcessHistory")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class FileProcessHistory : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new FileProcessHistory object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static FileProcessHistory CreateFileProcessHistory(global::System.Guid id)
        {
            FileProcessHistory fileProcessHistory = new FileProcessHistory();
            fileProcessHistory.ID = id;
            return fileProcessHistory;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                OnFileNameChanging(value);
                ReportPropertyChanging("FileName");
                _FileName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FileName");
                OnFileNameChanged();
            }
        }
        private global::System.String _FileName;
        partial void OnFileNameChanging(global::System.String value);
        partial void OnFileNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FileFolder
        {
            get
            {
                return _FileFolder;
            }
            set
            {
                OnFileFolderChanging(value);
                ReportPropertyChanging("FileFolder");
                _FileFolder = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FileFolder");
                OnFileFolderChanged();
            }
        }
        private global::System.String _FileFolder;
        partial void OnFileFolderChanging(global::System.String value);
        partial void OnFileFolderChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> OpenTime
        {
            get
            {
                return _OpenTime;
            }
            set
            {
                OnOpenTimeChanging(value);
                ReportPropertyChanging("OpenTime");
                _OpenTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OpenTime");
                OnOpenTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _OpenTime;
        partial void OnOpenTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnOpenTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> CloseTime
        {
            get
            {
                return _CloseTime;
            }
            set
            {
                OnCloseTimeChanging(value);
                ReportPropertyChanging("CloseTime");
                _CloseTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CloseTime");
                OnCloseTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _CloseTime;
        partial void OnCloseTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnCloseTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String BookMark
        {
            get
            {
                return _BookMark;
            }
            set
            {
                OnBookMarkChanging(value);
                ReportPropertyChanging("BookMark");
                _BookMark = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("BookMark");
                OnBookMarkChanged();
            }
        }
        private global::System.String _BookMark;
        partial void OnBookMarkChanging(global::System.String value);
        partial void OnBookMarkChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Guid> FileGuid
        {
            get
            {
                return _FileGuid;
            }
            set
            {
                OnFileGuidChanging(value);
                ReportPropertyChanging("FileGuid");
                _FileGuid = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FileGuid");
                OnFileGuidChanged();
            }
        }
        private Nullable<global::System.Guid> _FileGuid;
        partial void OnFileGuidChanging(Nullable<global::System.Guid> value);
        partial void OnFileGuidChanged();

        #endregion
    
    }

    #endregion
    
}
