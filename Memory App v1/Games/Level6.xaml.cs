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
    /// 
    public sealed partial class Level6 : Page
    {
        static string[] unitsShowns = new string[12];

        DateTime dateTime = new DateTime();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();


        public Level6()
        {
            this.InitializeComponent();

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
                CreateNumber();
                BeginsAnimation();
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
            }
        }

        private void CreateNumber()
        {
            Random random = new Random();

            for (int i = 0; i < 5; i ++)
            {
                unitsShowns[i] = random.Next(1, 10).ToString();
            }

            for (int i = 5; i <6; i++)
            {
                unitsShowns[i] = random.Next(10, 100).ToString();
            }

            for (int i = 6; i < 12; i ++)
            {
                unitsShowns[i] = random.Next(1, 10).ToString();
            }

            //changes text of the textblocks to the values stored in unitsShowns

            textblock1.Text = unitsShowns[0];
            textblock2.Text = unitsShowns[1];
            textblock3.Text = unitsShowns[2];
            textblock4.Text = unitsShowns[3];
            textblock5.Text = unitsShowns[4];
            textblock6.Text = unitsShowns[5];
            textblock7.Text = unitsShowns[6];
            textblock8.Text = unitsShowns[7];
            textblock9.Text = unitsShowns[8];
            textblock10.Text = unitsShowns[9];
            textblock11.Text = unitsShowns[10];
            textblock12.Text = unitsShowns[11];
        }

        //This method set the to and from positions of the textblocks and begins the storyboard animation
        private void BeginsAnimation()
        {
            da_viewbox1.From = viewboxUnitsShowing1.ActualWidth * -1;
            da_viewbox1.To = Frame.ActualWidth + 10;

            da_viewbox2.From = viewboxUnitsShowing2.ActualWidth * -1;
            da_viewbox2.To = Frame.ActualWidth + 10;

            da_viewbox3.From = viewboxUnitsShowing3.ActualWidth * -1;
            da_viewbox3.To = Frame.ActualWidth + 10;

            da_viewbox4.From = viewboxUnitsShowing4.ActualWidth * -1;
            da_viewbox4.To = Frame.ActualWidth + 10;

            da_viewbox5.From = viewboxUnitsShowing5.ActualWidth * -1;
            da_viewbox5.To = Frame.ActualWidth + 10;

            da_viewbox6.From = viewboxUnitsShowing6.ActualWidth * -1;
            da_viewbox6.To = Frame.ActualWidth + 10;

            da_viewbox7.From = viewboxUnitsShowing7.ActualWidth * -1;
            da_viewbox7.To = Frame.ActualWidth + 10;

            da_viewbox8.From = viewboxUnitsShowing8.ActualWidth * -1;
            da_viewbox8.To = Frame.ActualWidth + 10;

            da_viewbox9.From = viewboxUnitsShowing9.ActualWidth * -1;
            da_viewbox9.To = Frame.ActualWidth + 10;

            da_viewbox10.From = viewboxUnitsShowing10.ActualWidth * -1;
            da_viewbox10.To = Frame.ActualWidth + 10;

            da_viewbox11.From = viewboxUnitsShowing11.ActualWidth * -1;
            da_viewbox11.To = Frame.ActualWidth + 10;

            da_viewbox12.From = viewboxUnitsShowing12.ActualWidth * -1;
            da_viewbox12.To = Frame.ActualWidth + 10;

            stry1.Begin();
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level6Answer));
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
            Frame.Navigate(typeof(Level6));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
