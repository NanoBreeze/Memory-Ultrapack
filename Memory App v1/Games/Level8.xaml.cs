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
    public sealed partial class Level8 : Page
    {
        static string unitsDisplayed = "";

        public Level8()
        {
            this.InitializeComponent();

            Random random = new Random();

            unitsDisplayed += random.Next(1, 10).ToString();

            for (int i = 0; i < 15; i++)
            {
                unitsDisplayed += random.Next(0, 10).ToString();
            }

            tbkUnitsShowing1.Text = unitsDisplayed;
        }

        public static string UnitsDisplayed
        {
            get { return unitsDisplayed; }
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level8Answer));
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
    }
}
