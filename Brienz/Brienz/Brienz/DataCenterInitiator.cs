using System;
using System.Collections.Generic;
using System.Text;
using Brienz.Windows;
using System.Windows;
using System.Windows.Threading;

namespace Brienz
{
    public class DataCenterInitiator
    {
        public static void InitDataCenter()
        {
            MainWindow mainWindow = Application.Current.MainWindow.FindName("BrienzMainWindow") as MainWindow;
            mainWindow.FamilyDataPanel.Dispatcher.BeginInvoke(new Action<System.Windows.Controls.StackPanel>((Main) => {
             Main.Children.Add(new Widget("Family"));
            }),mainWindow.FamilyDataPanel);
            mainWindow.EmotionDataPanel.Dispatcher.BeginInvoke(new Action<System.Windows.Controls.StackPanel>((Main) =>
            {
                Main.Children.Add(new Widget("Emotion"));
            }), mainWindow.EmotionDataPanel);
            mainWindow.FriendsDataPanel.Dispatcher.BeginInvoke(new Action<System.Windows.Controls.StackPanel>((Main) =>
            {
                Main.Children.Add(new Widget("Friend(SocialIntercourse )"));
            }), mainWindow.FriendsDataPanel);
            mainWindow.HealthDataPanel.Dispatcher.BeginInvoke(new Action<System.Windows.Controls.StackPanel>((Main) =>
            {
                Main.Children.Add(new Widget("Health"));
            }), mainWindow.HealthDataPanel);
            mainWindow.JobDataPanel.Dispatcher.BeginInvoke(new Action<System.Windows.Controls.StackPanel>((Main) =>
            {
                Main.Children.Add(new Widget("Job"));
            }), mainWindow.JobDataPanel);
            mainWindow.LifeDataPanel.Dispatcher.BeginInvoke(new Action<System.Windows.Controls.StackPanel>((Main) =>
            {
                Main.Children.Add(new Widget("Live"));
            }), mainWindow.LifeDataPanel);
        } 
    }
}
