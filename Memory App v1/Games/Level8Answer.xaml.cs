using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1.Games
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level8Answer : Page
    {
        bool advanceToB4 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
        DispatcherTimer setFontSize = new DispatcherTimer();

        public Level8Answer()
        {
            this.InitializeComponent();
            setFontSize.Interval = TimeSpan.FromMilliseconds(20);
            setFontSize.Tick += setFontSize_Tick;
            setFontSize.Start();
        }

        void setFontSize_Tick(object sender, object e)
        {
            setFontSize.Stop();
            setFontSize.Tick -= setFontSize_Tick;
            tbx_UnitsShowing1_Answer.FontSize = tbx_UnitsShowing1_Answer.ActualHeight * 0.8;
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;

            bool allRight = true;

            //we set maxlength to prevent overflow
            for (int i = 0; i < tbx_UnitsShowing1_Answer.Text.Length; i ++)
            {
                 if (tbx_UnitsShowing1_Answer.Text[i] == Level8.UnitsDisplayed[i])
                 {
                     tbkResult.Text += "\nDigit " + (i+1).ToString() + " : Correct";
                 }
                 else
                 {
                     tbkResult.Text += "\nDigit " + (i + 1).ToString() + " : Incorrect || Correct Answer: " + Level8.UnitsDisplayed[i];
                     allRight = false;
                     tbx_UnitsShowing1_Answer.Foreground = new SolidColorBrush(Colors.Red);
                     advanceToB4 = false;
                 }
            }

            for (int i = tbx_UnitsShowing1_Answer.Text.Length; i <16; i ++)
            {
                tbkResult.Text += "\nDigit " + (i + 1).ToString() + " : Missed || Correct Answer: " + Level8.UnitsDisplayed[i];
                allRight = false;

                advanceToB4 = false;
            }

            if (allRight == true)
            {
                tbx_UnitsShowing1_Answer.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (advanceToB4)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
                settings.Values["B4"] = 1;
            }

        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level8));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level9));
        }
    }
}
