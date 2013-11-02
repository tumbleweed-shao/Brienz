using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.IO;
using Brienz.ViewModel;

namespace Brienz.Windows
{
    /// <summary>
    /// Interaction logic for Widget.xaml
    /// </summary>
    public partial class Widget : UserControl
    {
        public Widget()
        {
            InitializeComponent();
        }
        public Widget(string PlateNode): this()
        {
            XmlDocument xd = new XmlDocument();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\dfdf.xml", System.Text.Encoding.GetEncoding("GB2312"));
            xd.Load(sr);
            XmlNode xnList = xd.SelectSingleNode("/Root/Folder/Folder[@Name='"+PlateNode+"']");
            if (xnList != null)
            {
                xd.LoadXml(xnList.OuterXml);
                XmlDataProvider dataProvider = this.FindResource("xmlDataProvider") as XmlDataProvider;
                dataProvider.Document = xd;
            }
            this.treeVResource.DataContext = xd;
            
        }
        private void btOpenFileFolder_Click(object sender, RoutedEventArgs e)
        {
            TreeView tr = this.FindName("treeVResource") as TreeView;
            System.Xml.XmlCharacterData kk = tr.SelectedItem as System.Xml.XmlCharacterData;
            MessageBox.Show(kk.Value);
        }

        private void text_Loaded(object sender, RoutedEventArgs e)
        {
          BrienzViewModel vm =  this.FindName("ViewModelInstance") as BrienzViewModel;

          //var doc = this.Resources["NodeTemplate"] as HierarchicalDataTemplate;
          //var text = ((TextBlock)LogicalTreeHelper.FindLogicalNode(doc, "text")).Text;
          //vm.CurrentSelectFilePath = ((TextBlock)this.FindName("text")).Text;
        }

        private void btLearntFromIt_Click(object sender, RoutedEventArgs e)
        {
            LearntFromIt BPLL = new LearntFromIt();
            BPLL.ShowDialog();
        }
      
    }
}
