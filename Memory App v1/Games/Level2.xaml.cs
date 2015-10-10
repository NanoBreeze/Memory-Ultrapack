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
    public sealed partial class Level2 : Page
    {

 

        static string[] unitsShowns = new string[11];

        public Level2()
        {
            this.InitializeComponent();

            Random random = new Random();

            for (int i = 0; i < 6; i ++)
            {
                int digit = random.Next(0, 10);
                unitsShowns[i] = digit.ToString();
                tbkUnitsShowing.Text += digit + " ";
            }

            string[] capLetters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};    

            for (int i = 6; i < 9; i ++ )
            {
                int digit = random.Next(0, 26);
                unitsShowns[i] = capLetters[digit];
                tbkUnitsShowing.Text += capLetters[digit] + " ";
            }

            string[] symbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" };

            for (int i = 9; i < 11; i++)
            {
                int digit = random.Next(0, 10);
                unitsShowns[i] = symbols[digit];
                tbkUnitsShowing.Text += symbols[digit] + " ";
            }

        }

      

        public static string[] UnitsShowns
        {
            get { return unitsShowns; }
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level2Answer));
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level12));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
