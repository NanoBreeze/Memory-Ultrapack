using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Level4 : Page
    {
        DateTime dateTime = new DateTime();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        DateTime startTime = new DateTime();
        DispatcherTimer startTimer = new DispatcherTimer();


        string[] symbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" };
        Random random = new Random();

        static string[] unitsShowns = new string[8];

        public Level4()
        {
            this.InitializeComponent();

            tbkUnitsShowing1.Text = "";
            tbkUnitsShowing2.Text = "";

            //we set the symbols in tbxUnitsShowing1 and tbxUnitsShowing2
            for (int i = 0; i < 4; i++)
            {
                string temp = symbols[random.Next(0, 10)];
                unitsShowns[i] = temp;
                tbkUnitsShowing1.Text += temp + " ";
            }

            for (int i = 4; i < 8; i++)
            {
                string temp = symbols[random.Next(0, 10)];
                unitsShowns[i] = temp;
                tbkUnitsShowing2.Text += temp + " ";
            }


            startTimer.Interval = TimeSpan.FromSeconds(1);  
            startTime = startTime.AddSeconds(5);
            startTimer.Tick += startTimer_Tick;
            startTimer.Start();

            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dateTime = dateTime.AddSeconds(10);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        void startTimer_Tick(object sender, object e)
        {
            if (startTime.Second == 2)
            {
                stryInstructions.Begin();
            }

            if (startTime.Second == 0)
            {
                viewboxUnitsShowing1.Opacity = 1;
                da_viewboxUnitsShowing1.From = viewboxUnitsShowing1.ActualWidth * -1;
                da_viewboxUnitsShowing1.To = Frame.ActualWidth + 10;
                da_viewboxUnitsShowing1.Duration = new Duration(TimeSpan.FromSeconds(15));

                startTimer.Stop();
                startTimer.Tick -= startTimer_Tick;

                stry_tbkUnitsShowing1.Begin();
            }
            else
            {
                startTime = startTime.AddSeconds(-1);
            }
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            if (dateTime.Second == 0)
            {
                viewboxUnitsShowing2.Opacity = 1;

                da_viewboxUnitsShowing2.From = viewboxUnitsShowing2.ActualWidth * -1;
                da_viewboxUnitsShowing2.To = Frame.ActualWidth + 10;
                da_viewboxUnitsShowing2.Duration = new Duration(TimeSpan.FromSeconds(15));

                dispatcherTimer.Stop();
                dispatcherTimer.Tick -= dispatcherTimer_Tick;

                stry_tbkUnitsShowing2.Begin();
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
            }
        }

        public static string[] UnitsShowns
        {
            get { return unitsShowns; }
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level4Answer));
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level4));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
