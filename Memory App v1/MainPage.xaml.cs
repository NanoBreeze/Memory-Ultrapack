using Memory_App_v1.Common;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Memory_App_v1
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();

            //creates app settings for games page, 0 is locked and 1 is opened
            settings.Values["A1"] = 1;

            if (settings.Values["A2"] == null)
            {
                settings.Values["A2"] = 0;
            }
            if (settings.Values["A3"] == null)
            {
                settings.Values["A3"] = 0;
            }
            if (settings.Values["A4"] == null)
            {
                settings.Values["A4"] = 0;
            }
            if (settings.Values["A5"] == null)
            {
                settings.Values["A5"] = 0;
            }

            //B section
            if (settings.Values["B1"] == null)
            {
                settings.Values["B1"] = 0;
            }
            if (settings.Values["B2"] == null)
            {
                settings.Values["B2"] = 0;
            }
            if (settings.Values["B3"] == null)
            {
                settings.Values["B3"] = 0;
            }
            if (settings.Values["B4"] == null)
            {
                settings.Values["B4"] = 0;
            }
            if (settings.Values["B5"] == null)
            {
                settings.Values["B5"] = 0;
            }

            //C section
            if (settings.Values["C1"] == null)
            {
                settings.Values["C1"] = 0;
            }
            if (settings.Values["C2"] == null)
            {
                settings.Values["C2"] = 0;
            }
            if (settings.Values["C3"] == null)
            {
                settings.Values["C3"] = 0;
            }
            if (settings.Values["C4"] == null)
            {
                settings.Values["C4"] = 0;
            }
            if (settings.Values["C5"] == null)
            {
                settings.Values["C5"] = 0;
            }



            //creates app settings  to store the high score values for numbers
            object value1 = settings.Values["HighScore1_Number"];
            object value2 = settings.Values["HighScore2_Number"];
            object value3 = settings.Values["HighScore3_Number"];
            object value4 = settings.Values["HighScore4_Number"];
            object value5 = settings.Values["HighScore5_Number"];


            //the next 5 if statements used to be all if(value1 == null), changing them to corresponde with highscore number

            if (value1 == null)
                settings.Values["HighScore1_Number"] = -1;
            if (value2 == null)
                settings.Values["HighScore2_Number"] = -1;
            if (value3 == null)
                settings.Values["HighScore3_Number"] = -1;
            if (value4 == null)
                settings.Values["HighScore4_Number"] = -1;
            if (value5 == null)
                settings.Values["HighScore5_Number"] = -1;

            //creates app settings  to store the high score values for letters
            object value10 = settings.Values["HighScore1_Letter"];
            object value11 = settings.Values["HighScore2_Letter"];
            object value12 = settings.Values["HighScore3_Letter"];
            object value13 = settings.Values["HighScore4_Letter"];
            object value14 = settings.Values["HighScore5_Letter"];

            if (value10 == null)
                settings.Values["HighScore1_Letter"] = -1;
            if (value11 == null)
                settings.Values["HighScore2_Letter"] = -1;
            if (value12 == null)
                settings.Values["HighScore3_Letter"] = -1;
            if (value13 == null)
                settings.Values["HighScore4_Letter"] = -1;
            if (value14 == null)
                settings.Values["HighScore5_Letter"] = -1;


            //creates app settings  to store the high score values for symbols
            object value20 = settings.Values["HighScore1_Symbol"];
            object value21 = settings.Values["HighScore2_Symbol"];
            object value22 = settings.Values["HighScore3_Symbol"];
            object value23 = settings.Values["HighScore4_Symbol"];
            object value24 = settings.Values["HighScore5_Symbol"];

            if (value20 == null)
                settings.Values["HighScore1_Symbol"] = -1;
            if (value21 == null)
                settings.Values["HighScore2_Symbol"] = -1;
            if (value22 == null)
                settings.Values["HighScore3_Symbol"] = -1;
            if (value23 == null)
                settings.Values["HighScore4_Symbol"] = -1;
            if (value24 == null)
                settings.Values["HighScore5_Symbol"] = -1;


            //creates app settings to store the high score values for cards
            object value30 = settings.Values["HighScore1_Card"];
            object value31 = settings.Values["HighScore2_Card"];
            object value32 = settings.Values["HighScore3_Card"];
            object value33 = settings.Values["HighScore4_Card"];
            object value34 = settings.Values["HighScore5_Card"];

            if (value30 == null)
                settings.Values["HighScore1_Card"] = -1;
            if (value31 == null)
                settings.Values["HighScore2_Card"] = -1;
            if (value32 == null)
                settings.Values["HighScore3_Card"] = -1;
            if (value33 == null)
                settings.Values["HighScore4_Card"] = -1;
            if (value34 == null)
                settings.Values["HighScore5_Card"] = -1;
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            dispatcherTimer.Stop();
            dispatcherTimer.Tick -= dispatcherTimer_Tick;

            tbkLinyi.FontSize = nameRow.ActualHeight * 0.3;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Games.Level13));
           
        }

        private void mainPage_btnPractice_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Practice));
        }

        private void mainPage_btnTest_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test));
        }

        private void mainPage_btnGame_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void mainPage_btnHighscore_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Highscore));
        }

        private void gridPractice_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            //LinearGradientBrush gb = new LinearGradientBrush();
            //gb.StartPoint = new Point(0.5, 0);
            //gb.EndPoint = new Point(0.5, 1);

            //GradientStop colour1 = new GradientStop();
            //colour1.Color = Windows.UI.ColorHelper.FromArgb(255, 250, 250, 250);

            //GradientStop colour2 = new GradientStop();
            //colour2.Color = Windows.UI.ColorHelper.FromArgb(255, 200, 200, 200);

            //gb.GradientStops.Add(colour1);
            //gb.GradientStops.Add(colour2);

            tbkPractice.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectPractice.Fill = new SolidColorBrush(Colors.White);
            borderPractice.BorderBrush = new SolidColorBrush(Colors.DarkGreen);
            borderPractice.Opacity = 1;
        }

        private void gridPractice_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderPractice.Opacity = 0;
            rectPractice.Opacity = 0.5;
            rectPractice.Fill = new SolidColorBrush(Colors.Black);
            tbkPractice.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gridGame_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            tbkGames.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectGame.Fill = new SolidColorBrush(Colors.White);
            borderGames.BorderBrush = new SolidColorBrush(Color.FromArgb(255,189,131,28));
            borderGames.Opacity = 1;
        }

        private void gridGame_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderGames.Opacity = 0;
            rectGame.Opacity = 0.5;
            rectGame.Fill = new SolidColorBrush(Colors.Black);
            tbkGames.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gridTest_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            tbkkTest.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectTest.Fill = new SolidColorBrush(Colors.White);
            borderTest.Opacity = 1;
        }

        private void gridTest_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderTest.Opacity = 0;
            rectTest.Fill = new SolidColorBrush(Colors.Black);
            tbkkTest.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gridHighScores_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            tbkHighscores.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectHighScores.Fill = new SolidColorBrush(Colors.White);
            borderHighScores.Opacity = 1;
        }

        private void gridHighScores_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderHighScores.Opacity = 0;
            rectHighScores.Fill = new SolidColorBrush(Colors.Black);
            tbkHighscores.Foreground = new SolidColorBrush(Colors.White);
        }

        //pressing
        private void gridPractice_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridPractice.Background = new SolidColorBrush(Colors.DarkGreen);
        }

        private void gridPractice_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Practice));
        }

        private void gridGame_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridGame.Background = new SolidColorBrush(Color.FromArgb(255, 189, 131, 28));
        }

        private void gridGame_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void gridTest_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridTest.Background = new SolidColorBrush(Colors.RoyalBlue);
        }

        private void gridTest_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test));
        }

        private void gridHighScores_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridHighScores.Background = new SolidColorBrush(Colors.DarkCyan);
        }

        private void gridHighScores_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Highscore));
        }

        private void btnFeedBack_Click(object sender, RoutedEventArgs e)
        {
            tbkFeedback.Width = Frame.ActualWidth / 3.5;
            tbkFeedback.FontSize = Frame.ActualHeight / 45;
        }
    }
}
