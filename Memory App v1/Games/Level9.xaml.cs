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
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1.Games
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level9 : Page
    {
        static string[] unitsShowns = new string[18];

        DateTime dateTime = new DateTime();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Random random = new Random();

        DispatcherTimer startTimer = new DispatcherTimer();
        DateTime startTime = new DateTime();


        string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public Level9()
        {
            this.InitializeComponent();

           
            //sets the letters and numbers into "unitsShonwns"

            for (int i = 0; i < 12; i ++ )
            {
                unitsShowns[i] = letters[random.Next(0, 26)];
            }

            for (int i = 12; i < 18; i++ )
            {
                unitsShowns[i] = random.Next(0, 10).ToString();
            }

   
            //Timer before starting the first animation
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dateTime = dateTime.AddSeconds(5);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

     

        void dispatcherTimer_Tick(object sender, object e)
        {
            if (dateTime.Second == 2)
            {
                stryInstructions.Begin();
            }
            if (dateTime.Second == 0)
            {
                dispatcherTimer.Stop();

                //sets the first three letters in the rectangle's textblock

                tbkUnitsShowingChange.Text = "";
                tbkUnitsShowingChange.Text = unitsShowns[0] + unitsShowns[1] + unitsShowns[2];

                //sets the 6 numbers 

                tbkUnitsShowing1.Text = unitsShowns[12] + unitsShowns[13] + unitsShowns[14] +
                                         unitsShowns[15] + unitsShowns[16] + unitsShowns[17];

                ////when five seconds are up, we play the first animation for the canvas.
                //viewbox_tbkUnitsShowingChange.Height = rowContainingViewbox.ActualHeight;
                //viewbox_tbkUnitsShowingChange.Width = columnContainingViewbox.ActualWidth;

                //tbkUnitsShowingChange.Height = viewbox_tbkUnitsShowingChange.Height;
                //tbkUnitsShowingChange.Width = viewbox_tbkUnitsShowingChange.Width;

                da_viewbox1x.To = Frame.ActualWidth / 2 - gridContainingViewbox.ActualWidth/2;
                da_viewbox1y.To = Frame.ActualHeight / 2 * -1 + gridContainingViewbox.ActualHeight/2;

                stry1.Begin();
                stry1.Completed += stry1_Completed;
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
            }
        }

        void stry1_Completed(object sender, object e)
        {
            tbkUnitsShowingChange.Text = unitsShowns[3] + unitsShowns[4] + unitsShowns[5];
         
     
            da_viewbox2x.To = 0;
            da_viewbox2y.To = Frame.ActualHeight * -1 + gridContainingViewbox.ActualHeight;
            stry2.Begin();
            stry2.Completed += stry2_Completed;
        }

        void stry2_Completed(object sender, object e)
        {
            tbkUnitsShowingChange.Text = unitsShowns[6] + unitsShowns[7] + unitsShowns[8];



            da_viewbox3x.To = Frame.ActualWidth / 2 * -1 + gridContainingViewbox.ActualWidth / 2;
            da_viewbox3y.To = Frame.ActualHeight / 2 * -1 + gridContainingViewbox.ActualHeight / 2;
            stry3.Begin();
            stry3.Completed += stry3_Completed;
        }

        void stry3_Completed(object sender, object e)
        {
            tbkUnitsShowingChange.Text = unitsShowns[9] + unitsShowns[10] + unitsShowns[11];

            da_viewbox4x.To = 0;
            da_viewbox4y.To = 0;
            stry4.Begin();
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level9Answer));
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
            Frame.Navigate(typeof(Level9));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
