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
    public sealed partial class Level7 : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        DateTime dateTime = new DateTime();

        static string[] unitsShowns = new string[10];
        Random random = new Random();

        string[] letters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };

        public Level7()
        {
            this.InitializeComponent();

            dt.Interval = TimeSpan.FromSeconds(1);
            dateTime = dateTime.AddSeconds(5);
            dt.Tick += dt_Tick;
            dt.Start();

            CreateUnits();
        
        }

        void dt_Tick(object sender, object e)
        {
             if (dateTime.Second == 2)
             {
                 stryInstructions.Begin();
             }
            if (dateTime.Second == 0)
            {
                dt.Stop();
                dt.Tick -= dt_Tick;

                BeginAnimation();
            }
            else
            { dateTime = dateTime.AddSeconds(-1); }
        }

        private void CreateUnits()
        {
            for (int i = 0; i <4; i++)
            {
                unitsShowns[i] = random.Next(10, 100).ToString();
            }

            for (int i = 4; i <10; i++)
            {
                unitsShowns[i] = letters[random.Next(0, 51)].ToString();
            }

            tbkTopLeft.Text = unitsShowns[0];
            tbkTopRight.Text = unitsShowns[1];
            tbkBottomLeft.Text = unitsShowns[2];
            tbkBottomRight.Text = unitsShowns[3];

            textBlock1.Text = unitsShowns[4];
            textBlock2.Text = unitsShowns[5];
            textBlock3.Text = unitsShowns[6];
            textBlock4.Text = unitsShowns[7];
            textBlock5.Text = unitsShowns[8];
            textBlock6.Text = unitsShowns[9];
        }

        private void BeginAnimation()
        {
            stry1.Begin();
            stry2.Begin();
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level7Answer));
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
            Frame.Navigate(typeof(Level7));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
