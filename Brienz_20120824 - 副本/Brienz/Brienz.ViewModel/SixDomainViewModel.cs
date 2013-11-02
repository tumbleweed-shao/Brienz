using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.IO;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Brienz.Util;

namespace Brienz.ViewModel
{
    public class SixDomainViewModel : ViewModelBase 
    {
        private ObservableCollection<BrienzHierarchicalData> _brienzHierarchicalData = new ObservableCollection<BrienzHierarchicalData>();
        XmlDocument xd;
        BrienzHierarchicalData xmlData;
        public ICommand FileProcessStatusClick { get; set; }
        public SixDomainViewModel()
        {
            FileProcessStatusClick = new ChangeFileStatusCommand();
        }
        public void InitModel(string PlateNode)
        {
            RefreshDomainData(PlateNode);
        }
        
        public ObservableCollection<BrienzHierarchicalData> RefreshDomainData(string PlateNode)
        {
            try
            {
                ObservableCollection<BrienzHierarchicalData> _brienzHierarchicalData = new ObservableCollection<BrienzHierarchicalData>();
                xd = new XmlDocument();
                xmlData = new BrienzHierarchicalData();
                StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + ConstValue.XMLFileName, System.Text.Encoding.GetEncoding("utf-8"));
                xd.Load(sr);
                XmlNode xnList = xd.SelectSingleNode("/Brienz" + ConstValue.XMLFolderNS + ConstValue.XMLFolderNS + "[@" + ConstValue.XMLFileAttribute_FolderName + "='" + PlateNode + "']");
                if (xnList != null)
                {
                    XmlDocument temp = new XmlDocument();
                    temp.LoadXml(xnList.OuterXml);
                    _brienzHierarchicalData.Clear();
                    _brienzHierarchicalData = ReadXML(xnList.ChildNodes);
                    //BrienzHieData.RemoveAt(0);
                    //if (BrienzHieData.Count >= 1) BrienzHieData.RemoveAt(0);
                    //BrienzHieData.Add(m);

                    //XmlDataProvider dataProvider = this.FindResource("xmlDataProvider") as XmlDataProvider;
                    //dataProvider.Document = xd;
                }
                sr.Close();
                return _brienzHierarchicalData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private BrienzHierarchicalData ReadXML(BrienzHierarchicalData rootData, XmlNodeList NodeList)
        //{
        //    rootData.Children = new List<BrienzHierarchicalData>();
        //    foreach (XmlNode nodeIndex in NodeList)
        //    {
        //        BrienzHierarchicalData temp = new BrienzHierarchicalData();
        //        if (!nodeIndex.HasChildNodes)
        //        {
        //            temp.Data = nodeIndex.InnerText;
        //            temp.Attributes = nodeIndex.Attributes;
        //        }
        //        else
        //        {
        //            temp.Attributes = nodeIndex.Attributes;
        //            temp.Name = nodeIndex.Name;
        //            ReadXML(temp, nodeIndex.ChildNodes);
        //        }
        //        rootData.Children.Add(temp);
        //    }
        //    return rootData;
        //}
        private ObservableCollection<BrienzHierarchicalData> ReadXML(XmlNodeList NodeList)
        {
            try
            {
                foreach (XmlNode nodeIndex in NodeList)
                {
                    BrienzHierarchicalData BrienzData = new BrienzHierarchicalData();
                    XmlNode CurrentNode = nodeIndex;
                    if (CurrentNode.Name == ConstValue.FileNS)
                    {
                        while (true)
                        {
                            if (CurrentNode != null)
                            {
                                XmlNode getParent = CurrentNode.ParentNode;
                                if (getParent == null)
                                {
                                    BrienzData.FolderName = BrienzData.FolderName.Remove(BrienzData.FolderName.LastIndexOf('|'));
                                    break;
                                }
                                if (getParent.Name == ConstValue.FolderNS)
                                {
                                    if (getParent.Attributes[ConstValue.XMLFileAttribute_FolderName].Value != "Root")
                                    {
                                        BrienzData.FolderName = CurrentNode.ParentNode.Attributes[ConstValue.XMLFileAttribute_FolderName].Value + "|" + BrienzData.FolderName;
                                    }
                                }
                                CurrentNode = getParent;
                            }
                            else
                            {
                                BrienzData.FolderName = BrienzData.FolderName.Remove(BrienzData.FolderName.LastIndexOf('|'));
                                break;
                            }
                        }
                        if (nodeIndex.Name == ConstValue.FileNS)
                        {
                            BrienzData.FileName = nodeIndex.Attributes[ConstValue.XMLFileAttribute_FileName].Value;
                            BrienzData.FileStatus = nodeIndex.Attributes[ConstValue.XMLFileAttribute_FileStatus].Value;
                        }
                        _brienzHierarchicalData.Add(BrienzData);
                    }
                    else if (CurrentNode.Name == ConstValue.FolderNS)
                    {
                        if (CurrentNode.HasChildNodes)
                        {
                            ReadXML(nodeIndex.ChildNodes);
                        }
                        else
                        {
                            string CurrentFolderName = CurrentNode.Attributes[ConstValue.XMLFileAttribute_FolderName].Value;
                            while (true)
                            {
                                if (CurrentNode != null)
                                {
                                    XmlNode getParent = CurrentNode.ParentNode;
                                    if (getParent == null)
                                    {
                                        BrienzData.FolderName = BrienzData.FolderName + CurrentFolderName;
                                        break;
                                    }
                                    if (getParent.Name == ConstValue.FolderNS)
                                    {
                                        if (getParent.Attributes[ConstValue.XMLFileAttribute_FolderName].Value != "Root")
                                        {
                                            BrienzData.FolderName = getParent.Attributes[ConstValue.XMLFileAttribute_FolderName].Value + "|" + BrienzData.FolderName;
                                        }
                                    }
                                    CurrentNode = getParent;
                                }
                                else
                                {
                                    BrienzData.FolderName = BrienzData.FolderName + CurrentFolderName;
                                    break;
                                }
                            }
                            _brienzHierarchicalData.Add(BrienzData);
                        }
                    }
                    
                    
                    
                    
                }
                return _brienzHierarchicalData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ICommand ButtonCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Console.Write("sd");
                });
            }
        }

        public int GetDomainDataNumber(string PlateNode)
        {
            xd = new XmlDocument();
            xmlData = new BrienzHierarchicalData();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + ConstValue.XMLFileName, System.Text.Encoding.GetEncoding("utf-8"));
            xd.Load(sr);
            XmlNode xnList = xd.SelectSingleNode("/Brienz" + ConstValue.XMLFolderNS + ConstValue.XMLFolderNS + "[@" + ConstValue.XMLFileAttribute_FolderName + "='" + PlateNode + "']");
            int totalNumber = 0;
            ReadXMLForDomainCount(xnList.ChildNodes, ref totalNumber);
            return totalNumber;
        }
        private void ReadXMLForDomainCount(XmlNodeList NodeList, ref int totalNumber)
        {
            foreach (XmlNode nodeIndex in NodeList)
            {

                //temp.Data = nodeIndex.InnerText;
                if (nodeIndex.Name == ConstValue.FileNS)
                {
                    totalNumber++;
                }
                else
                {
                    ReadXMLForDomainCount(nodeIndex.ChildNodes,ref totalNumber);
                }
            }
        }
        private DelegateCommand<object> openSelectedFile;
        public DelegateCommand<object> OpenSelectedFile
        {
            get
            {
                if (openSelectedFile == null)
                {
                    openSelectedFile = new DelegateCommand<object>(new Action<object>((obj) => {
                        Console.Write("sd");
                    }));
                }
                return openSelectedFile;
            }
        }
        #region PropertyDefine
        private string _currentSelectedFilePath;
        public string CurrentSelectFilePath
        {
            get
            {
                
                return _currentSelectedFilePath;
            }
            set
            {
                if (_currentSelectedFilePath != value)
                {
                    _currentSelectedFilePath = value;
                    OnPropertyChanged("CurrentSelectFilePath");
                }
            }
        }
        //public List<BrienzHierarchicalData> BrienzHieData
        //{
        //    get { return _brienzHierarchicalData; }
        //    set
        //    {
        //        if (_brienzHierarchicalData == value)
        //        {
        //            return;
        //        }
        //        _brienzHierarchicalData = value;
        //        OnPropertyChanged("BrienzHieData");
        //    }
        //}
        private string data;
        public string Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged("Data");
                }
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        //private static object _selectedItem = null;
        //public static object SelectedItem
        //{
        //    get { return _selectedItem; }
        //    private set
        //    {
        //        if (_selectedItem != value)
        //        {
        //            _selectedItem = value;
        //            OnSelectedItemChanged();
        //        }
        //    }
        //}
        //static void OnSelectedItemChanged()
        //{
        //    // Raise event / do other things
        //    Console.Write("nixiangzenyang");
        //}
        //private bool _isSelected;
        //public bool IsSelected
        //{
        //    get { return _isSelected; }
        //    set
        //    {
        //        if (_isSelected != value)
        //        {
        //            _isSelected = value;
        //            OnPropertyChanged("IsSelected");
        //            if (_isSelected)
        //            {
        //                SelectedItem = this;
        //            }
        //        }
        //    }
        //}
        //public object customObjectProperty {
        //    get
        //    {
        //        return "sdfsdf";
        //    }
        //    set
        //    {
        //    }
        //}
        #endregion
        
    }
    
}
