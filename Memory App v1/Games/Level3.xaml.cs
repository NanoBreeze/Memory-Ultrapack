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
    public sealed partial class Level3 : Page
    {

        static string[] unitsShowns = new string[12];
        static int numberOfCapitalNumber = 0;

        public Level3()
        {
            this.InitializeComponent();

            Random random = new Random();

            string[] letters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };


            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(0, 52);

                if (index>=0 && index <=25)
                {
                    numberOfCapitalNumber++;
                }

                unitsShowns[i] = letters[index];
                tbkUnitsShowing1.Text += letters[index] + " ";
            }

            for (int i = 5; i < 12; i ++)
            {
                int index = random.Next(0, 52);

                if (index >= 0 && index <= 25)
                {
                    numberOfCapitalNumber++;
                }

                unitsShowns[i] = letters[index];
                tbkUnitsShowing2.Text += letters[index] + " ";
            }
        }

        public static string[] UnitsShowns
        {
           get { return unitsShowns; }
        }

        public static int NumberOfCapitalNumber
        {
            get {return numberOfCapitalNumber; }
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level3Answer));
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level3));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
