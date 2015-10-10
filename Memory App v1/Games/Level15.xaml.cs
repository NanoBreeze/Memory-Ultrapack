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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1.Games
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level15 : Page
    {
        static string[] unitsShowns = new string[45];
        static string[] cardsShowns = new string[4];

        Random random = new Random();

        string[] letters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };

        string[] symbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" }; 

        public Level15()
        {
            this.InitializeComponent();

            //make numbers, letters, and symbols
            unitsShowns[0] = random.Next(1, 10).ToString();

            for (int i = 1; i < 20; i++)  //making numbers
            {
                unitsShowns[i] = random.Next(0, 10).ToString(); ;
            }

            for (int i = 20; i < 30; i++)  //making capital letters
            {
                unitsShowns[i] = letters[random.Next(0, 26)];
            }

            for (int i = 30; i < 40; i++)  //making lowercase letters
            {
                unitsShowns[i] = letters[random.Next(26, 52)];
            }

            for (int i = 40; i < 45; i++)   //making symbols
            {
                unitsShowns[i] = symbols[random.Next(0, 10)];
            }

            //show numbers letters, and symbols

            tbkUnitsShowing1.Text = "";
            for (int i = 0; i < 20; i++)
            {
                tbkUnitsShowing1.Text += unitsShowns[i];
            }

            tbkUnitsShowing2.Text = "";
            for (int i = 20; i < 30; i++)
            {
                tbkUnitsShowing2.Text += unitsShowns[i];
            }

            tbkUnitsShowing3.Text = "";
            for (int i = 30; i < 40; i++)
            {
                tbkUnitsShowing3.Text += unitsShowns[i];
            }

            tbkUnitsShowing4.Text = "";
            for (int i = 40; i < 45; i++)
            {
                tbkUnitsShowing4.Text += unitsShowns[i];
            }

            //displaying cards
            #region choosing card
            switch (random.Next(1, 14))
            {
                case 1:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S1.png"));
                    cardsShowns[0] = ("S1");


                    //images to the latest/last stackpanel in the list.
                    break;
                case 2:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S2.png"));
                    cardsShowns[0] = ("S2");

                    //images to the latest/last stackpanel in the list.
                    break;
                case 3:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S3.png"));
                    cardsShowns[0] = ("S3");


                    break;
                case 4:
                   image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S4.png"));
                    cardsShowns[0] = ("S4");

                    break;
                case 5:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S5.png"));
                    cardsShowns[0] = ("S5");

                    break;
                case 6:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S6.png"));
                    cardsShowns[0] = ("S6");

                    break;
                case 7:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S7.png"));
                    cardsShowns[0] = ("S7");

                    break;
                case 8:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S8.png"));
                    cardsShowns[0] = ("S8");

                    break;
                case 9:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S9.png"));
                    cardsShowns[0] = ("S9");


                    break;
                case 10:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S10.png"));
                    cardsShowns[0] = ("S10");

                    break;
                case 11:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S11.png"));
                    cardsShowns[0] = ("S11");

                    break;
                case 12:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S12.png"));
                    cardsShowns[0] = ("S12");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 13:
                    image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S13.png"));
                    cardsShowns[0] = ("S13");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
            }
            switch (random.Next(14,27))
            {
                case 14:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H1.png"));
                    cardsShowns[1] = ("H1");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 15:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H2.png"));
                    cardsShowns[1] = ("H2");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 16:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H3.png"));
                    cardsShowns[1] = ("H3");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 17:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H4.png"));
                    cardsShowns[1] = ("H4");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 18:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H5.png"));
                    cardsShowns[1] = ("H5");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 19:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H6.png"));
                    cardsShowns[1] = ("H6");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 20:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H7.png"));
                    cardsShowns[1] = ("H7");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 21:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H8.png"));
                    cardsShowns[1] = ("H8");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 22:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H9.png"));
                    cardsShowns[1] = ("H9");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 23:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H10.png"));
                    cardsShowns[1] = ("H10");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 24:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H11.png"));
                    cardsShowns[1] = ("H11");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 25:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H12.png"));
                    cardsShowns[1] = ("H12");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 26:
                    image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H13.png"));
                    cardsShowns[1] = ("H13");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
            }
            switch (random.Next(27,40))
            {
                case 27:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D1.png"));
                    cardsShowns[2] = ("D1");


                    //images to the latest/last stackpanel in the list.
                    break;
                case 28:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D2.png"));
                    cardsShowns[2] = ("D2");

                    //images to the latest/last stackpanel in the list.
                    break;
                case 29:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D3.png"));
                    cardsShowns[2] = ("D3");


                    break;
                case 30:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D4.png"));
                    cardsShowns[2] = ("D4");

                    break;
                case 31:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D5.png"));
                    cardsShowns[2] = ("D5");

                    break;
                case 32:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D6.png"));
                    cardsShowns[2] = ("D6");

                    break;
                case 33:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D7.png"));
                    cardsShowns[2] = ("D7");

                    break;
                case 34:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D8.png"));
                    cardsShowns[2] = ("D8");

                    break;
                case 35:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D9.png"));
                    cardsShowns[2] = ("D9");


                    break;
                case 36:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D10.png"));
                    cardsShowns[2] = ("D10");

                    break;
                case 37:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D11.png"));
                    cardsShowns[2] = ("D11");

                    break;
                case 38:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D12.png"));
                    cardsShowns[2] = ("D12");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 39:
                    image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D13.png"));
                    cardsShowns[2] = ("D13");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
            }

            switch (random.Next(40,53))
            {
                case 40:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/H1.png"));
                    cardsShowns[3] = ("C1");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 41:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C2.png"));
                    cardsShowns[3] = ("C2");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 42:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C3.png"));
                    cardsShowns[3] = ("C3");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 43:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C4.png"));
                    cardsShowns[3] = ("C4");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 44:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C5.png"));
                    cardsShowns[3] = ("C5");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 45:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C6.png"));
                    cardsShowns[3] = ("C6");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 46:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C7.png"));
                    cardsShowns[3] = ("C7");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 47:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C8.png"));
                    cardsShowns[3] = ("C8");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 48:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C9.png"));
                    cardsShowns[3] = ("C9");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 49:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C10.png"));
                    cardsShowns[3] = ("C10");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 50:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C11.png"));
                    cardsShowns[3] = "C11";

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 51:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C12.png"));
                    cardsShowns[3] = "C12";

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 52:
                    image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C13.png"));
                    cardsShowns[3] = "C13";

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                default:
                    throw new ArgumentException("Something unexpected happened");
            }
        }
            #endregion

        public static string[] UnitsShowns
        {
            get {return unitsShowns;}
        }

        public static string[] CardsShowns
        {
            get {return cardsShowns;}
        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level15Answer));
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level15));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
   }
}

