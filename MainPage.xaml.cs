using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BinaryClockTry1.Resources;
using System.Windows.Threading;
using System.Windows.Media;
using Microsoft.Phone.Tasks;
using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace BinaryClockTry1
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool Unbleded = false;
        private bool NotInAnimation = true;
        //private Visibility ShowOverflowSegments =  Visibility.Collapsed; 
        List<FrameworkElement> HideOverflowSegements = new List<FrameworkElement>();

        // Konstruktor
        public MainPage()
        {
            InitializeComponent();

            // Beispielcode zur Lokalisierung der ApplicationBar
            //BuildLocalizedApplicationBar();

            this.UnhideNerdBlendStoryboard.Completed += UnhideNerdBlendStoryboard_Completed;
            this.HideOverflowSegements.Add(HideOverflowSegements1);
            this.HideOverflowSegements.Add(HideOverflowSegements2);
            this.HideOverflowSegements.Add(HideOverflowSegements3);
            this.HideOverflowSegements.Add(HideOverflowSegements4);
            this.HideOverflowSegements.Add(HideOverflowSegements5);
            this.HideOverflowSegements.Add(HideOverflowSegements6);
            this.HideOverflowSegements.Add(HideOverflowSegements7);
            this.HideOverflowSegements.Add(HideOverflowSegements8);
            this.HideOverflowSegements.Add(HideOverflowSegements9);
            this.HideOverflowSegements.Add(HideOverflowSegements10);
            this.HideOverflowSegements.Add(HideOverflowSegements11);
            this.HideOverflowSegements.Add(HideOverflowSegements12);
            this.HideOverflowSegements.Add(HideOverflowSegements13);
            this.HideOverflowSegements.Add(HideOverflowSegements14);
            this.HideOverflowSegements.Add(HideOverflowSegements15);
            
        }

        void UnhideNerdBlendStoryboard_Completed(object sender, EventArgs e)
        {
            //SystemTray.ForegroundColor = (Application.Current.Resources["PhoneForegroundBrush"] as SolidColorBrush).Color;
            this.NotInAnimation = true;
        }

        
        private void Border_DoubleTap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
               
        }

        private void TextBlock_DoubleTap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            e.Handled = false;
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
         
            var showOverflowSegmentsSetting = (IsolatedStorageSettings.ApplicationSettings.FirstOrDefault((key) => key.Key == "ShowOverflowSegments")).Value;
            Visibility showOverflowSegmentsResult;

            showOverflowSegmentsResult = (showOverflowSegmentsSetting != null && ((bool?)showOverflowSegmentsSetting).HasValue && ((bool?)showOverflowSegmentsSetting).Value) == true ? Visibility.Visible : Visibility.Collapsed; 

            foreach (FrameworkElement inFE in this.HideOverflowSegements)
            {
                inFE.Visibility = showOverflowSegmentsResult;
            }

            //var data = new FlipTileData
            //{
            //    BackBackgroundImage = new Uri("Assets/Tiles/01ClockOffIcon800x.png", UriKind.Relative),
            //    //BackBackgroundImage = new Uri("01ClockIcon100x.png"),
            //};

            //ShellTile.ActiveTiles.First().Update(data);


        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            WebBrowserTask wtask = new WebBrowserTask();
            wtask.Uri = new Uri("http://www.windowsphone.com/de-de/store/app/pomodoro-nl/1ab75520-7cb0-4a41-9697-3600af134397");
            wtask.Show();
        }

        private void Border_DoubleTap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.Unbleded && NotInAnimation)
            {
                //SystemTray.ForegroundColor = Colors.Transparent;
                this.UnhideNerdBlendStoryboard.Stop();
                this.Unbleded = false;
            }
            else
            {
                    this.NotInAnimation = false;
                    UnhideNerdBlendStoryboard.Begin();
                    this.Unbleded = true;
                        
            }
            
        }

        [Conditional("DEBUG")]
        private void Plus10Hour_Click_1(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "Plus1Minute":
                    {
                        //if (((ClockViewModel)this.DataContext).ManipulateTime.Minutes == 59)
                        //{
                        //    ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Add(TimeSpan.FromMinutes(-59.0));
                        //}
                        //else
                        //{
                            ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Add(TimeSpan.FromMinutes(1.0));
                        //}
                        break;
                    }
                case "Plus10Minute":
                    {
                        //if (((ClockViewModel)this.DataContext).ManipulateTime.Minutes >= 50)
                        //{
                        //    ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Add(TimeSpan.FromMinutes(-((ClockViewModel)this.DataContext).ManipulateTime.Minutes));
                        //}
                        //else
                        //{
                            ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Add(TimeSpan.FromMinutes(+10.0));
                        //}
                        break;
                    }
                case "Plus1Hour":
                    {
                    //    if (((ClockViewModel)this.DataContext).ManipulateTime.Hours == 9)
                    //    {
                    //        ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Add(TimeSpan.FromHours(-9.0));
                    //    }
                    //    else
                    //    {
                            ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Add(TimeSpan.FromHours(1.0));
                        //}
                        break;
                    }
                case "Plus10Hour":
                    {
                        //if (((ClockViewModel)this.DataContext).ManipulateTime.Hours >= 20)
                        //{
                        //    ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Add(TimeSpan.FromHours(-((ClockViewModel)this.DataContext).ManipulateTime.Hours));
                        //}
                        //else
                        //{
                            ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Add(TimeSpan.FromHours(+10.0));
                        //}
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            if (((ClockViewModel)this.DataContext).ManipulateTime.Days >= 1)
                ((ClockViewModel)this.DataContext).ManipulateTime = ((ClockViewModel)this.DataContext).ManipulateTime.Subtract(((ClockViewModel)this.DataContext).ManipulateTime);

            Debug.WriteLine(((ClockViewModel)this.DataContext).ManipulateTime);


        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        // Beispielcode zur Erstellung einer lokalisierten ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // ApplicationBar der Seite einer neuen Instanz von ApplicationBar zuweisen
        //    ApplicationBar = new ApplicationBar();

        //    // Eine neue Schaltfläche erstellen und als Text die lokalisierte Zeichenfolge aus AppResources zuweisen.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Ein neues Menüelement mit der lokalisierten Zeichenfolge aus AppResources erstellen
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}