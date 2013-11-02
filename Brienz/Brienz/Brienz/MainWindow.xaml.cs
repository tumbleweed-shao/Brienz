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
using Brienz.Windows;

namespace Brienz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                RootArchitect.RootArchitect RA = new RootArchitect.RootArchitect();
                RA.ComposeRootStruct();
                DataCenterInitiator.InitDataCenter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btAddAction_Click(object sender, RoutedEventArgs e)
        {
            BrienzAction brienzActionWindow = new BrienzAction();
            brienzActionWindow.ShowDialog();
        }
    }
}
