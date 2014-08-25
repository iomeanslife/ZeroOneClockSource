using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace BinaryClockTry1
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void ToggleButton_IsEnabledChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            var showOverflowSegmentsSetting = (IsolatedStorageSettings.ApplicationSettings.FirstOrDefault((key) => key.Key == "ShowOverflowSegments")).Value;

            if (showOverflowSegmentsSetting != null )
            {
                this.ToggleShowBinaryOferflow.IsChecked = ((bool?)showOverflowSegmentsSetting);
            }
            else
            {
                this.ToggleShowBinaryOferflow.IsChecked = false;
            }            
        }

        private void ToggleShowBinaryOferflow_Checked(object sender, RoutedEventArgs e)
        {
            CheckingTogle();
        }

        private void ToggleShowBinaryOferflow_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckingTogle();
        }

        private void CheckingTogle()
        {
            var showOverflowSegmentsSetting = (IsolatedStorageSettings.ApplicationSettings.FirstOrDefault((key) => key.Key == "ShowOverflowSegments")).Value;

            if (showOverflowSegmentsSetting == null)
            {
                IsolatedStorageSettings.ApplicationSettings.Add("ShowOverflowSegments", this.ToggleShowBinaryOferflow.IsChecked);
            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings["ShowOverflowSegments"] = this.ToggleShowBinaryOferflow.IsChecked;
            }
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }
}