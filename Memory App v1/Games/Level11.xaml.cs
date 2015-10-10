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
    public sealed partial class Level11 : Page
    {
        static string[] unitsShowns = new string[24];

        string[] letters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };

        string[] symbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" };

        DateTime dateTime = new DateTime();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        DateTime startT = new DateTime();
        DispatcherTimer startTimer = new DispatcherTimer();

        Random random = new Random();
        int a = 0;          //counter for which number to use

        public Level11()
        {
            this.InitializeComponent();
            
            //==make numbers, letters, and symbols
            //numbers
            for (int i = 0; i < 4; i++)
            {
                unitsShowns[i] = random.Next(100, 1000).ToString();
            }

            //letters
            for (int i = 4; i < 12; i++ )
            {
                unitsShowns[i] = letters[random.Next(0, 52)];
            }

            //symbols
            for (int i = 12; i < 24; i++)
            {
                unitsShowns[i] = symbols[random.Next(0, 10)];
            }

            startT = startT.AddSeconds(5);
            startTimer.Interval = TimeSpan.FromSeconds(1);
            startTimer.Tick += startTimer_Tick;
            startTimer.Start();

            
       }

        void startTimer_Tick(object sender, object e)
        {
            if (startT.Second == 2)
            {
                stryInstructions.Begin();
            }
            if (startT.Second == 0)
            {

                startTimer.Stop();
                startTimer.Tick -= startTimer_Tick;
                //==display the letters, and symbols

                tbkUnitsShowing1.Text = "";
                for (int i = 4; i < 8; i++)
                {
                    tbkUnitsShowing1.Text += unitsShowns[i];
                }

                tbkUnitsShowing2.Text = "";
                for (int i = 8; i < 12; i++)
                {
                    tbkUnitsShowing2.Text += unitsShowns[i];
                }

                tbkUnitsShowing3.Text = "";
                for (int i = 12; i < 18; i++)
                {
                    tbkUnitsShowing3.Text += unitsShowns[i];
                }

                tbkUnitsShowing4.Text = "";
                for (int i = 18; i < 24; i++)
                {
                    tbkUnitsShowing4.Text += unitsShowns[i];
                }

                //showing numbers that change
                tbkUnitsChanging.Text = unitsShowns[a];
                ShowingNumbers();
            }
            else
            {
                startT = startT.AddSeconds(-1);
            }

        }

        private void ShowingNumbers()
        {
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;

            if (a==0)       //we want the game to start right away
            {
                dateTime = dateTime.AddSeconds(1);
            }
            else
            {
                dateTime = dateTime.AddSeconds(10);
            }

            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            if (dateTime.Second == 0)
            {
                dispatcherTimer.Tick -= dispatcherTimer_Tick;
                dispatcherTimer.Stop();

                //a is the number of times 10-second intervals have passed, and corresponds to the unit shown by tbkUnitsChanging
                if (a != 4)
                {
                    tbkUnitsChanging.Text = unitsShowns[a];
                    a++;
                    ShowingNumbers();
                }
                else
                {
                    tbkUnitsChanging.Opacity = 0;
                }

                //after the first 11-second interval, the animations begin
                if (a == 1)
                {
                    da_viewbox_tbkUnitsShowing1.From = viewbox_tbkUnitsShowing1.ActualWidth * -1;
                    da_viewbox_tbkUnitsShowing1.To = Frame.ActualWidth + 10;

                    da_viewbox_tbkUnitsShowing2.From = viewbox_tbkUnitsShowing2.ActualWidth * -1;
                    da_viewbox_tbkUnitsShowing2.To = Frame.ActualWidth + 10;

                    da_viewbox_tbkUnitsShowing3.From = viewbox_tbkUnitsShowing3.ActualWidth * -1;
                    da_viewbox_tbkUnitsShowing3.To = Frame.ActualWidth + 10;

                    da_viewbox_tbkUnitsShowing4.From = viewbox_tbkUnitsShowing4.ActualWidth * -1;
                    da_viewbox_tbkUnitsShowing4.To = Frame.ActualWidth + 10;

                    stry1.Begin();
                    stry2.Begin();
                    stry3.Begin();
                    stry4.Begin();
                }
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
            }
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level11Answer));
        }

        public static string[] UnitsShowns
        {
            get { return unitsShowns; }
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level11));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
