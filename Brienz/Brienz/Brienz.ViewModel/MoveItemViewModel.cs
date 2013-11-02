using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml;
using System.IO;
using Brienz.Util;

namespace Brienz.ViewModel
{
    public class FolderProperty
    {
        public string FolderName { set; get; }
        public int FldID { set; get; }
    }
    public class MoveItemViewModel:ViewModelBase
    {

    }
    public class FolderItemArr : ObservableCollection<FolderProperty>
    {
        int index = 0;
        public FolderItemArr()
        {
            XmlDocument xd = new XmlDocument();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + ConstValue.XMLFileName, System.Text.Encoding.GetEncoding("utf-8"));
            xd.Load(sr);
            XmlNodeList xnList = xd.SelectNodes("/Brienz/Folder/Folder");
            List<FolderProperty> outValue = new List<FolderProperty>();
            TraverseNodes(xnList, outValue);
            foreach (FolderProperty index in outValue)
            {
                this.Add(index);
            }
        }

        private List<FolderProperty> TraverseNodes(XmlNodeList nodes, List<FolderProperty> outPropertyValue)
        {
            foreach (XmlNode node in nodes)
            {
                if (node.Name == "Folder")
                {
                    outPropertyValue.Add(new FolderProperty { FldID = ++index, FolderName = node.Attributes[ConstValue.XMLFileAttribute_FolderName].Value });
                }
                TraverseNodes(node.ChildNodes, outPropertyValue);
            }
            return outPropertyValue;
        }
    }  
}
