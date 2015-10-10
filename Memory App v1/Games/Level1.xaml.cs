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
    public sealed partial class Level1 : Page
    {
        static string[] unitsdisplayeds = new string[7];

        //allows us to set elements to actual height and width almost instantaneously
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DateTime dateTime = new DateTime();

        public Level1()
        {
            this.InitializeComponent();

            Random random = new Random();

            for (int i = 0; i < 5; i ++)
            {
                int digit = random.Next(0, 10);
                unitsdisplayeds[i] = digit.ToString();
                tbkToMemorize.Text += digit + " ";
            }

            string[] capLetters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};    

            for (int i = 5; i < 7; i ++ )
            {
                int digit = random.Next(0, 26);
                unitsdisplayeds[i] = capLetters[digit];
                tbkToMemorize.Text += capLetters[digit] + " ";
            }

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(50);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {

                tbkInstructions.FontSize = Frame.ActualHeight / 8;
                tbkToMemorize.FontSize = Frame.ActualHeight / 10;
 
        }

        public static string[] UnitsDisplayeds
        {
            get { return unitsdisplayeds; }
        }

        private void btnAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level1Answer));
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level1));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
